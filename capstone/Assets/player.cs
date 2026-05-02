using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Text text;

    Rigidbody2D rb;
    float footstepTimer = 0f;
    [SerializeField] float speed = 5f;

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
   

    public int hp = 100;
    public int damage = 10;
    public float stamina = 100f;
    public float mana = 100f;

    float attack3Timer = 0f;
    float angleee = 0;
    public GameObject playercanvas;
    public bool leoChangeScene;
    public GameObject mgmgmgmgmg;
    public int maxHp = 100;
    public float maxStamina = 100f;
    public float maxMana = 100f;


    public float cooldownArrow = 0f;
    public float cooldownPunch = 0f;
    public float cooldownWolf = 0f;
    [SerializeField] float maxCooldownArrow = 3f;
    [SerializeField] float maxCooldownPunch = 0.8f;
    [SerializeField] float maxCooldownWolf = 5f;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ani = GameObject.Find("player").GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mgmgmgmgmg = GameObject.Find("mgmgmgmgmg");
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
        mgmgmgmgmg.GetComponent<SpriteRenderer>().enabled = false;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Change Scene") != null)
            leoChangeScene = GameObject.Find("Change Scene").GetComponent<ChangesScene>().kavBool;
        else
            leoChangeScene = false;

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

            if (Input.GetKeyDown(KeyCode.Alpha2) && mana > 20 && cooldownArrow <= 0f)
            {
                ani.SetTrigger("attack");
                soundManager.GetComponent<soundmanger>().PlaySFX(8);
                mana -= 20;
                cooldownArrow = maxCooldownArrow;
                StartCoroutine(useArrow());
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && mana > 10 && cooldownPunch <= 0f)
            {
                ani.SetTrigger("attack2");
                StartCoroutine(PunchAttack());
                mana -= 10;
                cooldownPunch = maxCooldownPunch;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && cooldownWolf <= 0f)
            {
                StartCoroutine(Useattack3());
                cooldownWolf = maxCooldownWolf;
            }

            if (cooldownArrow > 0f)
                cooldownArrow -= Time.deltaTime;
            if (cooldownPunch > 0f) 
                cooldownPunch -= Time.deltaTime;
            if (cooldownWolf > 0f) 
                cooldownWolf -= Time.deltaTime;

            if (cooldown > 0f)
                cooldown -= Time.deltaTime;
            else
                sprintCooldown = false;

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
                isSprinting = false;

            if (cooldown <= 0f && stamina < maxStamina)
                stamina += maxStamina * 0.1f * Time.deltaTime;

            stamina = Mathf.Clamp(stamina, 0f, maxStamina);
            mana = Mathf.Min(mana + maxMana * 0.05f * Time.deltaTime, maxMana);

            text.text = "HP: " + hp + "\nMana: " + (int)mana + "\nStamina: " + (int)stamina;

            footstepTimer -= Time.deltaTime;
            if (rb.linearVelocity.magnitude > 0.1f && footstepTimer <= 0f)
            {
                // soundManager.GetComponent<soundmanger>().PlaySFX(6);
                footstepTimer = 0.75f;
            }

            attack3Timer += Time.deltaTime;
        }

        playercanvas.SetActive(!leoChangeScene);
    }

    private IEnumerator Useattack3()
    {
        soundManager.GetComponent<soundmanger>().PlaySFX(9);
        mgmgmgmgmg.GetComponent<SpriteRenderer>().enabled = true;
        float dir = GetComponent<SpriteRenderer>().flipX ? -1f : 1f;

        GameObject a = Instantiate(DarkWolf_2d_Grafics, new Vector2(transform.position.x, transform.position.y - 1.75f), Quaternion.identity);
        GameObject b = Instantiate(DarkWolf_2d_Grafics, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);

        a.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        b.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

        yield return new WaitForSeconds(0.5f);
        a.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir, 0f).normalized * 10f;
        b.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir, 0f).normalized * 10f;

        Destroy(a, .5f);
        Destroy(b, .5f);
        mgmgmgmgmg.GetComponent<SpriteRenderer>().enabled = false;
        mana -= 5;
    }

    private void FixedUpdate()
    {
        if (attack3Timer > .01f)
        {
            mgmgmgmgmg.transform.rotation = Quaternion.Euler(45f, 0f, angleee++);
            attack3Timer = 0f;
        }

        float currentSpeed = isSprinting ? speed * 2f : speed;
        rb.linearVelocity = movement.normalized * currentSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dmg"))
            hp -= damage;
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