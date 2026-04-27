using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;
public class ChangesScene : MonoBehaviour
{
    [SerializeField] GameObject subScene;
    public bool isPickedUp;
    float chachUpTime = .55f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] float leftB;
    [SerializeField] float rightB;
    [SerializeField] float upB;
    [SerializeField] float bottomB;
    [SerializeField] GameObject Equip;
    [SerializeField] GameObject EquipmentPickUpRange;
    [SerializeField] CameraMove Camera;
    public GameObject[] subWeaponItems;
    public int lastIndex;
    public static ChangesScene Instance;
    public bool atLevelBoard;
    [SerializeField] AddEquipment AddEquipment;

    public bool kavBool;
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
        
        //Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        Equip = GameObject.FindGameObjectWithTag("InventoryTab");
        EquipmentPickUpRange = GameObject.FindGameObjectWithTag("PickUpEquipmentRange");
        atLevelBoard = false;
    }
    void Update()
    {
        if(!atLevelBoard &&!isPickedUp){////////////////////////////&& !AddEquipment.isPickedUp
            gameObject.transform.position = subScene.transform.position;
            AddEquipment.ShowEquipment();
        }
        else if(!atLevelBoard && isPickedUp){////////////////////////////&& AddEquipment.isPickedUp
            gameObject.transform.position = subScene.transform.position;
            AddEquipment.hideEquipment();
        }
        else if(atLevelBoard && !isPickedUp){////////////////////////////&& !AddEquipment.isPickedUp
            AddEquipment.hideEquipment();
        }
        else{
            AddEquipment.ShowEquipment();
        }
        /*if(!atLevelBoard){////////////////////////////&& !AddEquipment.isPickedUp
            gameObject.transform.position = subScene.transform.position;
            AddEquipment.ShowEquipment();
        }
        else if(!atLevelBoard ){////////////////////////////&& AddEquipment.isPickedUp
            AddEquipment.hideEquipment();
        }
        else if(atLevelBoard){////////////////////////////&& !AddEquipment.isPickedUp
            AddEquipment.hideEquipment();
        }
        else{
            AddEquipment.ShowEquipment();
        }*/
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

            if (isPickedUp && !AddEquipment.isSelecting)
            {
                Debug.Log("AAAAAS");
                AddEquipment.gameObject.transform.position = new Vector2(-5.13f, -17f);
            }
            gameObject.transform.position = new Vector2(-3.7f, 4.12f);
            
            goToLevelBoard();
            
            Camera.isAtLevelBoard = true;
            //
        }
        else
        {
            kavBool = false;
            //GameObject.Find("Player object 1").SetActive(true);
            Camera.isAtLevelBoard = false;
            Equip.SetActive(false);
            atLevelBoard = false;
            //SceneManager.LoadScene(lastIndex, LoadSceneMode.Additive);
            if (isPickedUp && !AddEquipment.isSelecting)
            {
                AddEquipment.gameObject.transform.position = new Vector2(-5.13f, -17f);
            }
            
            SceneManager.UnloadSceneAsync("LEO - level board");
            
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
        kavBool = true;
        //GameObject.Find("Player object 1").SetActive(false);
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
