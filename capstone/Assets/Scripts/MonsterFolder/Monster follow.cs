using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Monsterfollow : MonoBehaviour
{
    [SerializeField] float AttackRange;
    [SerializeField] GameObject playerLocation;
    [SerializeField] float speed;
    public bool inRange;
    Rigidbody2D rb;
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inRange = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            /*if ((playerLocation.transform.position.x - gameObject.transform.position.x) > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }*/
            if (Vector3.Distance(gameObject.transform.position, playerLocation.transform.position) > AttackRange)
            {
                //Debug.Log("Need to move to the player");
                direction = (playerLocation.transform.position - gameObject.transform.position).normalized;
                rb.linearVelocity = direction * speed;
            }
        }
    }
   
    public void SetFollowTarget(GameObject player)
    {
        playerLocation = player;
    }
    public void setInRange(bool isInRange)
    {
        inRange = isInRange;
    }
    public void stopforaSec(){
        speed = 0f;
        Invoke("hold", 3f);//------------------Problem
    }
    public void hold(){
        speed = 1.5f;
    }
}
