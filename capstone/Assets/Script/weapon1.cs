using UnityEngine;

public class weapon1 : MonoBehaviour
{
    [SerializeField] GameObject projectiles;
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("1 pressed");
           int dir =  player.GetComponent<SpriteRenderer>().flipX? -1:1;

           GameObject a =  Instantiate(projectiles,new Vector2(player.GetComponent<Transform>().position.x+1*dir , player.GetComponent<Transform>().position.y+1), player.GetComponent<Transform>().rotation);
           GameObject b = Instantiate(projectiles, new Vector2(player.GetComponent<Transform>().position.x + 1 * dir, player.GetComponent<Transform>().position.y), player.GetComponent<Transform>().rotation);
           GameObject c = Instantiate(projectiles, new Vector2(player.GetComponent<Transform>().position.x + 1 * dir, player.GetComponent<Transform>().position.y-1), player.GetComponent<Transform>().rotation);

            a.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir * 1, 1);
            b.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir * 1,0);
            c.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir * 1, -1);
            Destroy(a, 5f);
            Destroy(b, 5f);
            Destroy(c, 5f);

        }
        
    }
}
