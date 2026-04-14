using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;
public class ChangesScene : MonoBehaviour
{
    [SerializeField] GameObject Equip;
    [SerializeField] GameObject EquipmentPickUpRange;
    public GameObject[] subWeaponItems;
    public int lastIndex;
    public static ChangesScene Instance;
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
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
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
            Destroy(EquipmentPickUpRange);
            SceneManager.LoadScene("LEO - level board");

            //
        }
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            Equip.SetActive(false);
            
            //SceneManager.LoadScene(lastIndex, LoadSceneMode.Additive);
            SceneManager.LoadScene(lastIndex);
        }
    }

    public GameObject[] GetsubWeaponArray()
    {
        return subWeaponItems;
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
