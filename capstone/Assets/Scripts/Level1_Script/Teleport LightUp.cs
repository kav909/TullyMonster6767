using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeleportLightUp : MonoBehaviour
{
    [SerializeField] ItemStorage itemStorage;
    [SerializeField] Equip equip;
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    [SerializeField] GameObject Light3;
    [SerializeField] GameObject Light4;
    [SerializeField] int LightSpeed;
    [SerializeField] GameObject player;
    public float TargetShade;
    private SpriteRenderer sr1;
    private SpriteRenderer sr2;
    private SpriteRenderer sr3;
    private SpriteRenderer sr4;
    public float neededWaitTime = 1.3f;
    public float timeWaited;
    bool isin;
    public bool monsterIsDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.SetActive(false); <<--------------
        itemStorage = FindAnyObjectByType<ItemStorage>();
        equip = FindAnyObjectByType<Equip>();
        itemStorage.transform.position = new Vector2(transform.position.x, transform.position.y - 30f);
        equip.transform.position = new Vector2(transform.position.x, transform.position.y - 30f);
        isin = false;
        timeWaited = 0f;
        LightSpeed = 1;
        sr1 = Light1.GetComponent<SpriteRenderer>();
        sr2 = Light2.GetComponent<SpriteRenderer>();
        sr3 = Light3.GetComponent<SpriteRenderer>();
        sr4 = Light4.GetComponent<SpriteRenderer>();
    }
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)   ///<<--- 
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
        if (monsterIsDead)
        {
            Debug.Log(monsterIsDead);
            gameObject.SetActive(true);//<---------------------------
        }
        UnityEngine.Color color = sr1.color;
        color.a = Mathf.MoveTowards(color.a, TargetShade, LightSpeed * Time.deltaTime);
        sr1.color = color;
        sr2.color = color;
        sr3.color = color;
        sr4.color = color;
        if(isin){
            timeWaited += Time.deltaTime;
            if(timeWaited > neededWaitTime){
                isin = false;
                timeWaited = 0f;
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    SceneManager.LoadScene(7);
                    player.transform.position = new Vector2(-4.8f, -27f);
                }
                if(SceneManager.GetActiveScene().buildIndex == 7){
                    SceneManager.LoadScene(8);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isin = true;
        TargetShade = 1f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isin = false;
        TargetShade = 0f;
    }
    public void setOpacity(float opacity)
    {
        UnityEngine.Color color = sr1.color;
        color.a = opacity;
        sr1.color = color;

        color.a = opacity;
        sr2.color = color;

        color.a = opacity;
        sr3.color = color;

        color.a = opacity;
        sr4.color = color;
    }
}
