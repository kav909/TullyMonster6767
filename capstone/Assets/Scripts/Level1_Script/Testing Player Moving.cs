using Unity.Netcode;
using UnityEngine;

public class TestingScript : NetworkBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject TheTextWindow;
    [SerializeField] CameraMove cameraMove;
    Rigidbody2D rb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraMove cam = FindObjectOfType<CameraMove>();
        Monsterfollow target = FindObjectOfType<Monsterfollow>();
        if (cam != null)
        {
            cam.SetTransformTarget(transform);
        }
        if (target != null)
        {
            target.SetFollowTarget(gameObject);
        }
        if (IsOwner)
        {
            GetComponent<SpriteRenderer>().color = Color.coral;
        }
        speed = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector3.zero;
        if (!IsOwner) return;
    }
    void FixedUpdate()
    {

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.A))
        {
           // Debug.Log("go Left");
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
           // Debug.Log("go Right");
            moveX = 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
           // Debug.Log("go Up");
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
           // Debug.Log("go Down");
            moveY = -1f;
        }
        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
    public GameObject getTheTextWindow(){
        return TheTextWindow;
    }
}
