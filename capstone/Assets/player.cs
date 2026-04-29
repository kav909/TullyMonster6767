using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    public Text text;

    Rigidbody2D rb;
    float footstepTimer = 0f;
    float speed = 5f;


    [SerializeField] Animator ani;
    public GameObject soundManager;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject circle;
    Vector2 movement;
    public GameObject punchUp;
    public GameObject punchDown;
    public GameObject punchLeft;
    public GameObject punchRight;
    public GameObject DarkWolf_2d_Grafics;
    string currentDir = "down";
   
    public bool isSprinting = false;
    public float cooldown = 0f;
    public bool sprintCooldown = false;
    public GameObject playercanvas;
    public bool leoChangeScene;
    public GameObject magiccirclesigilcircle_0;
    public int hp;
    public int damage;
    public float stamina;
    public float mana;
    float attackBowTimer = 0f;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)   ////<<--- 
    {
        
        ani = GameObject.Find("player").GetComponent<Animator>();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        magiccirclesigilcircle_0 = GameObject.Find("magic-circle-sigil-circle_0");
        rb = GetComponent<Rigidbody2D>();
        text = GameObject.Find("playertext").GetComponent<Text>();
        soundManager = GameObject.Find("soundMain");

        punchDown = GameObject.Find("pldown");
        punchLeft = GameObject.Find("plleft");
        punchRight = GameObject.Find("plright");
        punchUp = GameObject.Find("plup");
        DarkWolf_2d_Grafics = GameObject.Find("DarkWolf_2d_Grafics");

        punchUp.SetActive(false);
        punchDown.SetActive(false);
        punchLeft.SetActive(false);
        punchRight.SetActive(false);

        playercanvas = GameObject.Find("playercanvas");

        GameObject levelupObj = GameObject.Find("levelup");
        if (levelupObj != null)
        {
            levelup stats = levelupObj.GetComponent<levelup>();
            hp = stats.GetMaxHP();
            mana = stats.GetMaxMana();
            stamina = stats.GetMaxStamina();
            damage = stats.GetDamage();
        }
        else
        {
            hp = 100;
            mana = 50;
            stamina = 20;
            damage = 10;
        }



    }

    void Update()
    {
        GameObject levelupObj = GameObject.Find("levelup");
        levelup stats = null;
        if (levelupObj != null)
            stats = levelupObj.GetComponent<levelup>();

        float maxHP = stats != null ? stats.GetMaxHP() : 100f;
        float maxMana = stats != null ? stats.GetMaxMana() : 50f;
        float maxStamina = stats != null ? stats.GetMaxStamina() : 20f;
        damage = stats != null ? stats.GetDamage() : 10;


        magiccirclesigilcircle_0.transform.rotation =  Quaternion.Euler(45f,0f,transform.rotation.z+1f* Time.deltaTime);
        if (GameObject.Find("Change Scene") != null)
        {
            leoChangeScene = GameObject.Find("Change Scene").GetComponent<ChangesScene>().kavBool;
        }
        else {
            leoChangeScene= false;  
        }
        if (hp < 1)
        {
            //gameObject.SetActive(false);
            //GameObject.Find("playercam").SetActive(true);
        }
        movement.x = 0;
        movement.y = 0;

        if (!leoChangeScene)
        {
           


            if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1;
                GetComponent<SpriteRenderer>().flipX = true;
                ani.SetBool("up", false);
                ani.SetBool("side", true);
                ani.SetBool("down", false);
                currentDir = "left";
            }

            if (Input.GetKey(KeyCode.D))
            {
                movement.x = 1;

                GetComponent<SpriteRenderer>().flipX = false;
                ani.SetBool("up", false);
                ani.SetBool("side", true);
                ani.SetBool("down", false);
                currentDir = "right";
            }
            if (Input.GetKey(KeyCode.W))
            {
                movement.y = 1;
                ani.SetBool("up", true);
                ani.SetBool("side", false);
                ani.SetBool("down", false);
                currentDir = "up";
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement.y = -1;
                ani.SetBool("up", false);
                ani.SetBool("side", false);
                ani.SetBool("down", true);
                currentDir = "down";
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && mana > 20)
            {
               
                float dir = GetComponent<SpriteRenderer>().flipX ? -1f : 1f;

                GameObject a = Instantiate(DarkWolf_2d_Grafics, new Vector2(transform.position.x, transform.position.y-1f), Quaternion.identity);
                a.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir, 0f).normalized * 10f;

                GameObject b = Instantiate(DarkWolf_2d_Grafics, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
                b.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir, 0f).normalized * 10f;


                a.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                b.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;


                //Vector2 pos = a.transform.position;
                Destroy(a,1.5f);
                Destroy(b,1.5f);
                mana -= 50;


            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && mana > 20)
            {
                ani.SetTrigger("attack");
                soundManager.GetComponent<soundmanger>().PlaySFX(8);
                mana -= 20;
                StartCoroutine(useArrow());
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && mana > 10)
            {
                ani.SetTrigger("attack2");

                StartCoroutine(PunchAttack());
                mana -= 10;
            }

            if (cooldown > 0f)
            {
                cooldown -= Time.deltaTime;
            }
            else
            {
                sprintCooldown = false;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && isSprinting)
            {
                isSprinting = false;
                cooldown = 2f;
                sprintCooldown = true;
            }

            if (Input.GetKey(KeyCode.LeftShift) && movement != Vector2.zero && stamina > 0 && cooldown <= 0f)
            {
                isSprinting = true;
                stamina -= 20f * Time.deltaTime;

                if (stamina <= 0f)
                {
                    isSprinting = false;
                    cooldown = 2f;
                    sprintCooldown = true;
                }
            }
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = false;
            }


            if (cooldown <= 0f && stamina < maxStamina)
                stamina += maxStamina * 0.1f * Time.deltaTime;

            stamina = Mathf.Clamp(stamina, 0f, maxStamina);

            mana = Mathf.Min(mana + maxMana * 0.05f * Time.deltaTime, maxMana);
            text.text = "HP: " + hp + "/" + (int)maxHP +
            "\nMana: " + (int)mana + "/" + (int)maxMana +
            "\nStamina: " + (int)stamina + "/" + (int)maxStamina;


            footstepTimer -= Time.deltaTime;
            if (rb.linearVelocity.magnitude > 0.1f && footstepTimer <= 0f)
            {
                // soundManager.GetComponent<soundmanger>().PlaySFX(6); 《----------------------
                footstepTimer = 0.75f;
            }
            
        }

        if (leoChangeScene)
        {
            playercanvas.SetActive(false);
        }
        else {
            playercanvas.SetActive(true);
        }
    }

   
    private void FixedUpdate()
    {
        float currentSpeed = isSprinting ? speed * 2f : speed;
        rb.linearVelocity = movement.normalized * currentSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dmg"))
        {
            hp -= damage;
            //Destroy(collision.gameObject);
        }
    }

    private IEnumerator useArrow()
    {
        float dir = GetComponent<SpriteRenderer>().flipX ? -1f : 1f;

        GameObject a = Instantiate(arrow, transform.position, Quaternion.identity);
        a.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir, 1f).normalized * 10f;
        a.transform.rotation = Quaternion.Euler(0, 0, dir > 0 ? -135f : -45f); 
        yield return new WaitForSeconds(0.5f);

        Vector2 pos = a.transform.position;
        Destroy(a);
        circle.transform.position = new Vector2(pos.x, pos.y - 5.5f);
        circle.SetActive(true);

        for (int i = 0; i < 10; i++)
        {
            float randX = Random.Range(-1f, 1f);
            GameObject a2 = Instantiate(arrow, new Vector2(pos.x + randX, pos.y), Quaternion.identity);
            a2.transform.rotation = Quaternion.Euler(0, 0, 90f);
            a2.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -1f).normalized * 10f;
            Destroy(a2, .5f);
            yield return new WaitForSeconds(0.1f); 
        }
        yield return new WaitForSeconds(.5f);
        circle.SetActive(false);
    }
    private IEnumerator PunchAttack()
    {
        soundManager.GetComponent<soundmanger>().PlaySFX(7);
        yield return new WaitForSeconds(0.25f);
        EnablePunch();
        yield return new WaitForSeconds(0.2f);
        punchUp.SetActive(false);
        punchDown.SetActive(false);
        punchLeft.SetActive(false);
        punchRight.SetActive(false);
    }

    private void EnablePunch()
    {
        punchUp.SetActive(false);
        punchDown.SetActive(false);
        punchLeft.SetActive(false);
        punchRight.SetActive(false);

        if (currentDir == "up") 
            punchUp.SetActive(true);
        if (currentDir == "down")
            punchDown.SetActive(true);
        if (currentDir == "left")
            punchLeft.SetActive(true);
        if (currentDir == "right") 
            punchRight.SetActive(true);
    }

}