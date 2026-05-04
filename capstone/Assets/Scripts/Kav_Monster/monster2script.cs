using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class monster2script : MonoBehaviour
{
    public GameObject swordUp;
    public GameObject swordDown;
    public GameObject swordLeft;
    public GameObject swordRight;

    [SerializeField] List<GameObject> fireballs;

    public GameObject player;
    public GameObject soundManager;
    Rigidbody2D rb;
    Animator ani;
    bool z;
    float attack1Timer = 0f;
    [SerializeField] float speed = 3f;
    [SerializeField] float attackRange = 10f;
    float footstepTimer = 0f;
    string currentDir = "down";
    bool hasLineOfSight;
    float distance;
    bool inRange = false;
    [SerializeField] float distanceThreshold = 5f;

    public int HP = 100;
    public float maxHP;

    void Start()
    {
        soundManager = GameObject.Find("soundMain");
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        swordDown = GameObject.Find("mdown");
        swordLeft = GameObject.Find("mleft");
        swordRight = GameObject.Find("mright");
        swordUp = GameObject.Find("mup");

        swordUp.SetActive(false);
        swordDown.SetActive(false);
        swordLeft.SetActive(false);
        swordRight.SetActive(false);
        maxHP = HP;

    }

    void Update()
    {
        if (HP < 1)
        {
            player.GetComponent<player>().hp = 100;
            gameObject.SetActive(false);
        }
        Vector2 direction = player.transform.position - transform.position;

        if (hasLineOfSight && inRange)
        {
            MoveToPlayer(direction);


            /*if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                rb.linearVelocity = Vector2.zero;
                ani.SetTrigger("attack");
                StartCoroutine(SwordAttack());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ani.SetTrigger("attack2");
                FireAttack();
            }*/

            attack1Timer -= Time.deltaTime;
            if (attack1Timer <= 0f)
            {
                attack1Timer = 5f;
                if (z)
                {
                    z = false;
                    rb.linearVelocity = Vector2.zero;
                    ani.SetTrigger("attack");
                    StartCoroutine(SwordAttack());
                }
                else
                {
                    z = true;
                    rb.linearVelocity = Vector2.zero;
                    ani.SetTrigger("attack2");
                    FireAttack();
                }
            }
        }
        
    }
    private void FixedUpdate()
    {
        hasLineOfSight = false;
        RaycastHit2D[] ray = Physics2D.RaycastAll(transform.position, player.transform.position - transform.position);
        if (ray.Length > 1 && ray[1].collider != null)
        {
            hasLineOfSight = ray[1].collider.gameObject == player;
            if (hasLineOfSight)
                Debug.DrawLine(transform.position, player.transform.position, Color.green);
            else
                Debug.DrawLine(transform.position, player.transform.position, Color.red);
        }

        distance = Vector2.Distance(transform.position, player.transform.position);
        inRange = distance < distanceThreshold;
    }
    private void MoveToPlayer(Vector2 direction)
    {
        footstepTimer -= Time.deltaTime;
        if (rb.linearVelocity.magnitude > 0.1f && footstepTimer <= 0f)
        {
            soundManager.GetComponent<soundmanger>().PlaySFX(0);
            footstepTimer = 0.35f;
        }
        Vector2 moveDir = direction.normalized;
        rb.linearVelocity = moveDir * speed;

        float absX = Mathf.Abs(direction.x);
        float absY = Mathf.Abs(direction.y);

        ani.SetBool("up", false);
        ani.SetBool("down", false);
        ani.SetBool("left", false);
        ani.SetBool("right", false);

        if (absX > absY)
        {
            if (direction.x > 0)
            {
                ani.SetBool("right", true);
                currentDir = "right";
            }
            else
            {
                ani.SetBool("left", true);
                currentDir = "left";
            }
        }
        else
        {
            if (direction.y > 0)
            {
                ani.SetBool("up", true);
                currentDir = "up";
            }
            else
            {
                ani.SetBool("down", true);
                currentDir = "down";
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerdmg"))
        {
            HP -= 10;
            //Destroy(collision.gameObject);
        }
    }
    private IEnumerator SwordAttack()
    {
        soundManager.GetComponent<soundmanger>().PlaySFX(5);
        yield return new WaitForSeconds(0.25f);

        EnableSword();

        yield return new WaitForSeconds(0.2f);

        swordUp.SetActive(false);
        swordDown.SetActive(false);
        swordLeft.SetActive(false);
        swordRight.SetActive(false);
    }

    private void EnableSword()
    {
        swordUp.SetActive(false);
        swordDown.SetActive(false);
        swordLeft.SetActive(false);
        swordRight.SetActive(false);

        if (currentDir == "up") 
            swordUp.SetActive(true);
        if (currentDir == "down") 
            swordDown.SetActive(true);
        if (currentDir == "left") 
            swordLeft.SetActive(true);
        if (currentDir == "right") 
            swordRight.SetActive(true);
    }

   

    private void FireAttack()
    {

        soundManager.GetComponent<soundmanger>().PlaySFX(1);
        for (int i = 0; i < fireballs.Count; i++)
        {
            float offsetX = (i - (fireballs.Count - 1) / 2f) * 1.1f;

            Vector3 spawnPos = transform.position + new Vector3(offsetX, 2f, 0);
            GameObject fire = Instantiate(fireballs[i],spawnPos, Quaternion.identity);
            Vector2 dir = (player.transform.position - fire.transform.position).normalized;
            fire.GetComponent<Rigidbody2D>().linearVelocity = dir * 5f;

            Destroy(fire, 3f);
        }
    }
}