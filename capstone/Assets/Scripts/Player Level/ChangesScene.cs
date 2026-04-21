using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;
public class ChangesScene : MonoBehaviour
{
    [SerializeField] UnityEngine.Transform target;
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
        target = GameObject.FindGameObjectWithTag("Player").transform;
        leftB = transform.position.x - 1.5f;
        rightB = transform.position.x + 1.5f;
        upB = transform.position.y + 0.5f;
        bottomB = transform.position.y - 0.5f;
        
        Equip = GameObject.FindGameObjectWithTag("InventoryTab");
        EquipmentPickUpRange = GameObject.FindGameObjectWithTag("PickUpEquipmentRange");
        atLevelBoard = false;
    }
    void Update()
    {
        if (target.position.x <= leftB || target.position.x >= rightB || target.position.y >= upB || target.position.y <= bottomB)
        {
            //   Debug.Log("Camera Move");
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, chachUpTime);
            leftB = transform.position.x - 0f;
            rightB = transform.position.x + 0f;
            upB = transform.position.y + 0f;
            bottomB = transform.position.y - 0f;
        }
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
