using UnityEngine;

public class MonsterRange : MonoBehaviour
{
    [SerializeField] GameObject Range;
    [SerializeField] Monsterfollow Monsterfollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Monsterfollow.setInRange(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Monsterfollow.setInRange(false);
        }
    }
}
