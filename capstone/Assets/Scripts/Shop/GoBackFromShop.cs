using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackFromShop : MonoBehaviour
{
    [SerializeField] Shopplace shopplace;
    public static GoBackFromShop Instance;
    [SerializeField] Interaction interaction;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //Destroy(gameObject); // destroy duplicate
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        shopplace = GameObject.Find("weapon shop").GetComponent<Shopplace>();
        //Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shopplace = GameObject.Find("weapon shop").GetComponent<Shopplace>();
    }
    private void OnMouseDown()
    {
        Debug.Log("sdfsdf");
        interaction.isInShop = false;
        shopplace.refresh();
        SceneManager.UnloadSceneAsync("Shop");

    }
    public void goToShop()
    {
        gameObject.transform.position = new Vector2(-6.83f, 203.19f);
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }
}
