using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class player : MonoBehaviour
{
    public Text text;

    Rigidbody2D rb;

    [SerializeField] float speed = 5f;
    [SerializeField] int hp = 100;
    [SerializeField] int damage = 10;
    [SerializeField] Animator ani;

    Vector2 movement;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        text = GameObject.Find("playertext").GetComponent<Text>();

    }

    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if (Input.GetKey(KeyCode.A)) {
            movement.x = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            ani.SetBool("up", false);
            ani.SetBool("side", true);
            ani.SetBool("down", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
           movement.x = 1;
           
          GetComponent<SpriteRenderer>().flipX = false;
            ani.SetBool("up", false);
            ani.SetBool("side", true);
            ani.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
            ani.SetBool("up", true);
            ani.SetBool("side", false);
            ani.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
            ani.SetBool("up", false);
            ani.SetBool("side", false);
            ani.SetBool("down", true);
        }

        if (Input.GetKey(KeyCode.Alpha3)) {
            ani.SetTrigger("attack");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ani.SetTrigger("attack2");
        }

          text.text = "HP: " + hp;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dmg"))
        {
            hp -= damage;
            //Destroy(collision.gameObject);
        }
    }


}