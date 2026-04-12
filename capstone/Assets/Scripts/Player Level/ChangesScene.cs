using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputManagerEntry;
public class ChangesScene : MonoBehaviour
{
    [SerializeField] Equip Equip;
    [SerializeField] GameObject EquipmentPickUpRange;
    public GameObject[] subWeaponItems;
    public int lastIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            subWeaponItems = Equip.GetWeaponArray();
            lastIndex = 3;
            foreach (GameObject obj in subWeaponItems)
            {
                if (obj != null)
                {
                    DontDestroyOnLoad(obj);
                }
            }
            Destroy(EquipmentPickUpRange);
            
            SceneManager.LoadScene(5);
            //
        }
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
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
