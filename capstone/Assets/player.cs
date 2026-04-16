using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Text text;

    Rigidbody2D rb;
    float footstepTimer = 0f;
    [SerializeField] float speed = 5f;
    [SerializeField] int hp = 100;
    [SerializeField] int damage = 10;
    [SerializeField] Animator ani;
    public GameObject soundManager;
    Vector2 movement;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)   ///<<--- 
    {
        text = GameObject.FindGameObjectWithTag("SubTag").GetComponent<Text>();
        ani = GameObject.Find("player").GetComponent<Animator>();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        text = GameObject.Find("playertext").GetComponent<Text>();
        soundManager = GameObject.Find("soundMain");
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
            soundManager.GetComponent<soundmanger>().PlaySFX(8);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ani.SetTrigger("attack2");
            soundManager.GetComponent<soundmanger>().PlaySFX(7);
        }

        footstepTimer -= Time.deltaTime;
        if (rb.linearVelocity.magnitude > 0.1f && footstepTimer <= 0f)
        {
            soundManager.GetComponent<soundmanger>().PlaySFX(6);
            footstepTimer = 0.75f;
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