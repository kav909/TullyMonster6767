using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstershootsBlades : MonoBehaviour
{
    [SerializeField] GameObject mob;
    [SerializeField] GameObject dmgfield;
    [SerializeField] List<GameObject> blades;

    public GameObject player;

    Rigidbody2D rb;
    Animator ani;

    [SerializeField] float speed = 3f;
    [SerializeField] float attackRange = 10f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        dmgfield.SetActive(false);
    }

    void Update()
    {
        
        Vector2 direction = player.transform.position - transform.position;

        if (direction.magnitude < attackRange)
        {
            MoveToPlayer(direction);

            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ani.SetTrigger("attack");
                UseWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                rb.linearVelocity = Vector2.zero;
                ani.SetTrigger("attack2");
                StartCoroutine(UseSwipe());
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

    private IEnumerator UseSwipe()
    {
        yield return new WaitForSeconds(0.3f); 
        dmgfield.SetActive(true);
        yield return new WaitForSeconds(0.2f); 
        dmgfield.SetActive(false);
    }
}