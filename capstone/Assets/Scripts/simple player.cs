using UnityEngine;
using UnityEngine.UI;


public class simpleplayer : MonoBehaviour
{
    [SerializeField] Text text;

    Rigidbody2D rb;

    [SerializeField] float speed = 5f;
    [SerializeField] int hp = 100;
    [SerializeField] int damage = 10;

    Vector2 movement;

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();

       
    }

    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if (Input.GetKey(KeyCode.A)) 
            movement.x = -1;
        if (Input.GetKey(KeyCode.D)) 
            movement.x = 1;
        if (Input.GetKey(KeyCode.W)) 
            movement.y = 1;
        if (Input.GetKey(KeyCode.S)) 
            movement.y = -1;
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