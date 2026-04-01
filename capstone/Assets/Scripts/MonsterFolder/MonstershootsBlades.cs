using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonstershootsBlades : MonoBehaviour
{
    [SerializeField] GameObject mob;
    [SerializeField] List<GameObject> blades;
    public GameObject player;
    Rigidbody2D rb;
    Animator ani;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 15)
        {
            float directionX = player.transform.position.x - transform.position.x > 0 ? 1 : -1;
            float directionY = player.transform.position.y - transform.position.y > 0 ? 1 : -1;
            rb.linearVelocity = new Vector2(directionX * 3f, directionY * 3f);
            /* if (directionX == -1)
             {
                 GetComponent<SpriteRenderer>().flipX = true;
                 ani.SetBool("moving", false);
             }
             else
             {
                 GetComponent<SpriteRenderer>().flipX = false;
             }*/
            if (Mathf.Abs(directionX) > Mathf.Abs(directionY))
            {
                ani.SetFloat("moveX", directionX);
                ani.SetFloat("moveY", 0);
            }
            else
            {
                ani.SetFloat("moveX", 0);
                ani.SetFloat("moveY", directionY);
            }

            ani.SetBool("moving", true);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ani.SetBool("moving", false);
            ani.SetFloat("moveX", 0);
            ani.SetFloat("moveY", 0);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 pressed");
            ani.SetTrigger("attack");
            UseWeapon();
        }

    }

    public void UseWeapon()
    {
        int dir = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        for (int i = 0; i < blades.Count; i++) {
            GameObject a = Instantiate(blades[i], new Vector2(mob.GetComponent<Transform>().position.x + 1 * dir*i, mob.GetComponent<Transform>().position.y + 5), player.GetComponent<Transform>().rotation);
            Vector3 direction = player.GetComponent<Transform>().position - a.GetComponent<Transform>().position;
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)-90;
            Debug.Log(angle);
            a.transform.rotation = Quaternion.Euler(0, 0, angle);
            a.GetComponent<Rigidbody2D>().linearVelocity= direction* .5f;


        }

        

               // Destroy(a, 5f);
        

    }
}
