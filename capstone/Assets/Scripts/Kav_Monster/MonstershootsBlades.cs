using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstershootsBlades : MonoBehaviour
{
    [SerializeField] GameObject mob;
    [SerializeField] GameObject dmgfield;
    [SerializeField] List<GameObject> blades;
    [SerializeField] TeleportLightUp teleportLightUp;
    public GameObject player;
    public GameObject soundManager;
    Rigidbody2D rb;
    Animator ani;
    float footstepTimer = 0f;
    float attack1Timer = 0f;
    float attack2Timer = 0f;
    [SerializeField] float speed = 3f;
    [SerializeField] float attackRange = 10f;
    bool hasLineOfSight;
    bool z;
    float distance;
    bool inRange = false;
    [SerializeField] float distanceThreshold = 5f;
    [SerializeField] GameObject drops;
    public int HP = 100;
    public float maxHP;

    void Start()
    {
        soundManager = GameObject.Find("soundMain");
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        dmgfield.SetActive(false);
        /*if(drops != null )
            drops.SetActive(false);*/

        maxHP = HP;
    }

    void Update()
    {
        if (HP <1)
        {
            /*if (drops != null)
                drops.SetActive(true);*/
            player.GetComponent<player>().hp = 100;
            teleportLightUp.gameObject.SetActive(true);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        Vector2 direction = player.transform.position - transform.position;

        if (hasLineOfSight && inRange)
        {
            MoveToPlayer(direction);


            /*  if (Input.GetKeyDown(KeyCode.Alpha1))
              {
                  ani.SetTrigger("attack");
                  UseWeapon();
              }

              if (Input.GetKeyDown(KeyCode.Alpha2))
              {
                  rb.linearVelocity = Vector2.zero;
                  ani.SetTrigger("attack2");
                  StartCoroutine(UseSwipe());
              }*/
            attack1Timer -= Time.deltaTime;
            if (attack1Timer <= 0f)
            {
                attack1Timer = 5f;
                if (z)
                {
                    z= false;
                    ani.SetTrigger("attack");
                    UseWeapon();
                }
                else {
                    z = true;
                    rb.linearVelocity = Vector2.zero;
                    ani.SetTrigger("attack2");
                    StartCoroutine(UseSwipe());
                }                         
            }
           
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ani.SetBool("up", false);
            ani.SetBool("down", false);
            ani.SetBool("left", false);
            ani.SetBool("right", false);
        }
    }

   private void MoveToPlayer(Vector2 direction)
    {
        footstepTimer -= Time.deltaTime;
        if (rb.linearVelocity.magnitude > 0.1f && footstepTimer <= 0f)
        {
            soundManager.GetComponent<soundmanger>().PlaySFX(2);
            footstepTimer = 0.75f;
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
                ani.SetBool("right", true);
            else
                ani.SetBool("left", true);
        }
        else
        {
            if (direction.y > 0)
                ani.SetBool("up", true);
            else
                ani.SetBool("down", true);
        }
    }



    public void UseWeapon()
    {
        soundManager.GetComponent<soundmanger>().PlaySFX(4);
        Vector2 baseDirection = (player.transform.position - transform.position).normalized;
        float centerAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg;
        float spread = 30f; 

        for (int i = 0; i < blades.Count; i++)
        {
            float angleOffset = 0;

            if (blades.Count > 1)
                angleOffset = Mathf.Lerp(-spread, spread, (float)i / (blades.Count - 1));

            float finalAngle = centerAngle + angleOffset;
            float rad = finalAngle * Mathf.Deg2Rad;

            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            GameObject blade = Instantiate(blades[i],transform.position + (Vector3)(dir * 1f),Quaternion.identity);
            blade.transform.rotation = Quaternion.Euler(0, 0, finalAngle - 90);
            blade.GetComponent<Rigidbody2D>().linearVelocity = dir * 5f;
            Destroy(blade, 3f);
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

    private IEnumerator UseSwipe()
    {
        soundManager.GetComponent<soundmanger>().PlaySFX(3);
        yield return new WaitForSeconds(0.3f); 
        dmgfield.SetActive(true);
        yield return new WaitForSeconds(0.2f); 
        dmgfield.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerdmg"))
        {
            HP -= 10;
            //Destroy(collision.gameObject);
        }
    }
}