using System.Collections.Generic;
using UnityEngine;

public class weapon1 : MonoBehaviour
{
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mob;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("1 pressed");
           UseWeapon();
        }
        
    }

    public void UseWeapon() {
        int dir = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        GameObject a = Instantiate(projectiles[0], new Vector2(mob.GetComponent<Transform>().position.x + 1 * dir, player.GetComponent<Transform>().position.y + 1), player.GetComponent<Transform>().rotation);
        GameObject b = Instantiate(projectiles[1], new Vector2(mob.GetComponent<Transform>().position.x + 1 * dir, player.GetComponent<Transform>().position.y), player.GetComponent<Transform>().rotation);
        GameObject c = Instantiate(projectiles[2], new Vector2(mob.GetComponent<Transform>().position.x + 1 * dir, player.GetComponent<Transform>().position.y - 1), player.GetComponent<Transform>().rotation);

        a.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir * 1, 1);
        b.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir * 1, 0);
        c.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(dir * 1, -1);

        Vector3 direction = (player.transform.position - a.transform.position).normalized;
        a.GetComponent<Rigidbody2D>().linearVelocity = direction * 1.1f;

        //Destroy(a, 5f);
        Destroy(b, 5f);
        Destroy(c, 5f);

    }
}
