using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;
public class ChangesScene : MonoBehaviour
{
    [SerializeField] GameObject Equip;
    [SerializeField] GameObject EquipmentPickUpRange;
    [SerializeField] CameraMove Camera;
    public GameObject[] subWeaponItems;
    public int lastIndex;
    public static ChangesScene Instance;
    public bool atLevelBoard;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Equip = GameObject.FindGameObjectWithTag("InventoryTab");
        EquipmentPickUpRange = GameObject.FindGameObjectWithTag("PickUpEquipmentRange");
        //Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        atLevelBoard = false;
    }
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!atLevelBoard)
        {
            Equip.SetActive(true);
            /*subWeaponItems = Equip.GetComponent<Equip>().GetWeaponArray();
            
            foreach (GameObject obj in subWeaponItems)
            {
                if (obj != null)
                {
                    DontDestroyOnLoad(obj);
                }
            }*/
            lastIndex = 3;
            //Equip = GameObject.FindGameObjectWithTag("InventoryTab");
            //SceneManager.LoadScene("LEO - level board");
            goToLevelBoard();
            gameObject.transform.position = new Vector2(-5.13f, 4f);
            Camera.isAtLevelBoard = true;
            //
        }
        else
        {
            Camera.isAtLevelBoard = false;
            Equip.SetActive(false);
            atLevelBoard = false;
            //SceneManager.LoadScene(lastIndex, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("LEO - level board");
            gameObject.transform.position = new Vector2(7.4613f, 4.261f);
        }
    }

    public GameObject[] GetsubWeaponArray()
    {
        return subWeaponItems;
    }
    public void goToLevelBoard(){
        SceneManager.LoadScene("LEO - level board", LoadSceneMode.Additive);
        atLevelBoard = true;
        Debug.Log("sdfdfsfajklds)");
    }
}

/*
public class ChangesScene : MonoBehaviour
{
    [SerializeField] Equip Equip;
    public GameObject[] subWeaponItems;
    //SceneManagement sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Equip = FindAnyObjectByType<Equip>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
   /* private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Equip = FindAnyObjectByType<Equip>();
        subWeaponItems = GameObject.FindGameObjectsWithTag("goToLevelBoard");

    }
    void Update()
    {
        
    }
    private void OnMouseDown(){
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            subWeaponItems = Equip.GetWeaponArray();
            SceneManager.LoadScene(5);
        }
        
        
    }
    public GameObject[] GetsubWeaponArray()
    {
        return subWeaponItems;
    }
}
*/
