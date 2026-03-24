using UnityEngine;
[SerializeField] float AttackRange;
[SerializeField] playerLocation;
public bool inRange;
public class Monsterfollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        inRange = true;
    }
}
}
