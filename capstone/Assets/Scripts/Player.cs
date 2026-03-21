using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] float speed = 10f;
   // [SerializeField] GameObject startx;
  //  [SerializeField] GameObject man;
    Rigidbody2D rb;
   // [SerializeField] GameObject starting;
   // [SerializeField] GameObject starting2;
   // [SerializeField] GameObject starting3;
    public bool onetime = true;
    public float speeeeed = 2f;

    //https://www.youtube.com/watch?v=_NLsWFgVX6E

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsOwner) {
            GetComponent<SpriteRenderer>().color = Color.coral;
       }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (true /*!man.GetComponent<manager>().end*/)
        {
            rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.linearVelocity.y);

            if (Input.GetAxisRaw("Horizontal") < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else if (Input.GetAxisRaw("Horizontal") > 0)
                GetComponent<SpriteRenderer>().flipX = false;
            if (onetime == false)
                transform.Translate(-Vector2.right * speeeeed * Time.deltaTime);


            if (grounded() && Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);
                ani.SetBool("jump", true);
                ani.SetBool("crouch", false);
                ani.SetBool("idle", false);
                ani.SetBool("run", false);
            }
            if (!grounded() && rb.linearVelocity.y < 0)
            {
                ani.SetBool("jump", false);
                ani.SetBool("crouch", true);
                ani.SetBool("idle", false);
                ani.SetBool("run", false);
            }


            if (grounded())
            {

                ani.SetBool("crouch", false);


                if (Mathf.Abs(rb.linearVelocity.y) < 0.1f)
                    ani.SetBool("jump", false);


                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    ani.SetBool("run", true);
                    ani.SetBool("idle", false);
                }
                else
                {
                    ani.SetBool("run", false);
                    ani.SetBool("idle", true);
                }
            }

          /*  if (transform.position.x > startx.transform.position.x && onetime)
            {
                onetime = false;
                //man.GetComponent<manager>().start = true;
                starting.GetComponent<Rigidbody2D>().linearVelocity = 2f * -transform.right;
                starting2.GetComponent<Rigidbody2D>().linearVelocity = 2f * -transform.right;
                starting3.GetComponent<Rigidbody2D>().linearVelocity = 2f * -transform.right;

                Destroy(starting3, 10f);
                Destroy(starting2, 10f);
                Destroy(starting, 10f);
            }*/
        }

    }

    private bool grounded()
    {
        bool isGrounded = false;

        Vector2 castFrom = new Vector2(transform.position.x, transform.position.y/* - GetComponent<PolygonCollider2D>().bounds.size.y / 2 - .01f*/);
        RaycastHit2D[] hit = Physics2D.RaycastAll(castFrom, Vector2.down, 5f);
        Debug.DrawRay(castFrom, (Vector2.down * .5f), Color.yellow, 2f, true);

        if (hit.Length > 1 && hit[hit.Length - 1].transform.tag == "ground")
            isGrounded = true;
        //Debug.Log(isGrounded);

        return isGrounded;
    }
}