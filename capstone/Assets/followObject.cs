using UnityEngine;

public class followObject : MonoBehaviour
{
    [SerializeField] GameObject g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = g.transform.position;
    }
}
