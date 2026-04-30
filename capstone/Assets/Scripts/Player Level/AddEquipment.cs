using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddEquipment : MonoBehaviour
{
    public bool isSelecting;
    
    public int AddATK;
    public int AddDEF;
    public int AddSPD;
    public int AddMAG;
    [SerializeField] int price;
    [SerializeField] levelup levelup;
    [SerializeField] ItemStorage itemStorage;
    [SerializeField] Equip Equip;
    [SerializeField] GameObject weaponSlot;
    [SerializeField] GameObject headSlot;
    [SerializeField] GameObject frontSlot;
    [SerializeField] GameObject bodySlot;
    [SerializeField] GameObject pantsSlot;
    [SerializeField] GameObject gloveSlot;
    [SerializeField] GameObject shoeSlot;
    public static AddEquipment Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Awake()
     {

         if (Instance != null && Instance != this)
         {
             //Destroy(gameObject);
             DontDestroyOnLoad(gameObject);
             return;
         }
         else{
            
         }

        Instance = this;
        

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

     //   levelup = GameObject.Find("Manager").GetComponent<levelup>();
        Debug.Log("Scene references reloaded");
    }
   
    
    void Start()
    {
        isSelecting = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        assign();
        Debug.Log("CHOOSEJDSJDSJ");
        if (gameObject.tag == "Weapon" && !weaponSlot.GetComponent<Inventory>().containEquipment)
        {
            weaponSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, weaponSlot);
            applyStats();
            isSelecting = true;
        }
        if (gameObject.tag == "Head" && !headSlot.GetComponent<Inventory>().containEquipment)
        {
            headSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, headSlot);
            applyStats();
            isSelecting = true;
        }
        if (gameObject.tag == "Front" && !frontSlot.GetComponent<Inventory>().containEquipment)
        {
            frontSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, frontSlot);
            applyStats();
            isSelecting = true;
        }
        if (gameObject.tag == "Body" && !bodySlot.GetComponent<Inventory>().containEquipment)
        {
            bodySlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, bodySlot);
            applyStats();
            isSelecting = true;
        }
        if (gameObject.tag == "Pants" && !pantsSlot.GetComponent<Inventory>().containEquipment)
        {
            pantsSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, pantsSlot);
            applyStats();
            isSelecting = true;
        }
        if (gameObject.tag == "Glove" && !gloveSlot.GetComponent<Inventory>().containEquipment)
        {
            gloveSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, gloveSlot);
            applyStats();
            isSelecting = true;
        }
        if (gameObject.tag == "Shoe" && !shoeSlot.GetComponent<Inventory>().containEquipment)
        {
            shoeSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, shoeSlot);
            applyStats();
            isSelecting = true;
        }
    }

    public bool getSelect()
    {
        return isSelecting;
    }
    public void IsSelecting()
    {
        isSelecting = true;
    }
    public void undoSelect()
    {
        isSelecting = false;
    }
    public void applyStats()
    {
        levelup.equipATK(AddATK);
        levelup.equipDEF(AddDEF);
        levelup.equipSPD(AddSPD);
        levelup.equipMAG(AddMAG);
    }
    public void unequipStats()
    {
        levelup.unequipATK(AddATK);
        levelup.unequipDEF(AddDEF);
        levelup.unequipSPD(AddSPD);
        levelup.unequipMAG(AddMAG);

    }
    public void hideEquipment(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void ShowEquipment(){
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void assign(){
        levelup = FindFirstObjectByType<levelup>();

        weaponSlot = GameObject.FindGameObjectWithTag("WeaponItem");
        headSlot = GameObject.FindGameObjectWithTag("HeadItem");
        frontSlot = GameObject.FindGameObjectWithTag("FrontItem");
        bodySlot = GameObject.FindGameObjectWithTag("BodyItem");
        pantsSlot = GameObject.FindGameObjectWithTag("PantsItem");
        gloveSlot = GameObject.FindGameObjectWithTag("GloveItem");
        shoeSlot = GameObject.FindGameObjectWithTag("ShoeItem");
    }
    public int getPrice()
    {
        return price;
    }
}
