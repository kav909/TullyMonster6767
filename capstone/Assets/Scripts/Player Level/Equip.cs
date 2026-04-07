using Newtonsoft.Json;
using UnityEngine;
using static UnityEditor.Progress;

public class Equip : MonoBehaviour
{
    [SerializeField] ItemStorage ItemStorage;
    GameObject[] HeadItem = new GameObject[12];
    GameObject[] FrontItem = new GameObject[12];
    GameObject[] BodyItem = new GameObject[12];
    GameObject[] PantsItem = new GameObject[12];
    GameObject[] GloveItem = new GameObject[12];
    GameObject[] ShoeItem = new GameObject[12];
    GameObject[] WeaponItem = new GameObject[12];
    GameObject[] itemArray = new GameObject[12];
    
    public GameObject equipedHead;
    public GameObject equipedFront;
    public GameObject equipedBody;
    public GameObject equipedPants;
    public GameObject equipedGlove;
    public GameObject equipedShoe;
    public GameObject equipedWeapon;

    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    [SerializeField] GameObject item4;
    [SerializeField] GameObject item5;
    [SerializeField] GameObject item6;
    [SerializeField] GameObject item7;
    [SerializeField] GameObject item8;
    [SerializeField] GameObject item9;
    [SerializeField] GameObject item10;
    [SerializeField] GameObject item11;
    [SerializeField] GameObject item12;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (ItemStorage == null)
        {
             ItemStorage = FindAnyObjectByType<ItemStorage>();
        }

        if (ItemStorage == null)
        {
            Debug.LogError("ItemStorage not found in scene!");
        }
    }
    void Start()
    {
        itemArray[0] = item1;
        itemArray[1] = item2; 
        itemArray[2] = item3;
        itemArray[3] = item4;
        itemArray[4] = item5;
        itemArray[5] = item6;
        itemArray[6] = item7;
        itemArray[7] = item8;
        itemArray[8] = item9;
        itemArray[9] = item10;
        itemArray[10] = item11;
        itemArray[11] = item12;
        //Debug.Log("what??"+ ItemStorage.getWeaponSlot()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (WeaponItem[0] == null)
        {
            Debug.Log("this is " + WeaponItem[0] + "is Null");
        }
    }
    public void ApplyWeapon()
    {
        WeaponItem[0] = ItemStorage.getWeaponSlot()[0];
        changeItemArray();
        for (int i = 0; i < WeaponItem.Length; i++)
        {
            if (WeaponItem[i] != null)
            {
                WeaponItem[i].transform.position = itemArray[i].transform.position;
                equipedWeapon = WeaponItem[i];
                WeaponItem[i] = null;
            }            
        }
    }
    public void ApplyHead()
    {
        HeadItem[0] = ItemStorage.getHeadSlot()[0];
        changeItemArray();
        for (int i = 0; i < HeadItem.Length; i++)
        {
            if (HeadItem[i] != null)
            {
                HeadItem[i].transform.position = itemArray[i].transform.position;
                equipedHead = HeadItem[i];
                HeadItem[i] = null;
            }
        }
    }
    public void ApplyFront()
    {
        FrontItem[0] = ItemStorage.getFrontSlot()[0];
        changeItemArray();
        for (int i = 0; i < FrontItem.Length; i++)
        {
            if (FrontItem[i] != null)
            {
                FrontItem[i].transform.position = itemArray[i].transform.position;
                equipedFront = FrontItem[i];
                FrontItem[i] = null;
            }
        }
    }
    public void ApplyBody()
    {
        BodyItem[0] = ItemStorage.getBodySlot()[0];
        changeItemArray();
        for (int i = 0; i < BodyItem.Length; i++)
        {
            if (BodyItem[i] != null)
            {
                BodyItem[i].transform.position = itemArray[i].transform.position;
                equipedBody = BodyItem[i];
                BodyItem[i] = null;
            }
        }
    }
    public void ApplyPants()
    {
        PantsItem[0] = ItemStorage.getPantsSlot()[0];
        changeItemArray();
        for (int i = 0; i < PantsItem.Length; i++)
        {
            if (PantsItem[i] != null)
            {
                PantsItem[i].transform.position = itemArray[i].transform.position;
                equipedPants = PantsItem[i];
                PantsItem[i] = null;
            }
        }
    }
    public void ApplyGlove()
    {
        GloveItem[0] = ItemStorage.getGloveSlot()[0];
        changeItemArray();
        for (int i = 0; i < GloveItem.Length; i++)
        {
            if (GloveItem[i] != null)
            {
                GloveItem[i].transform.position = itemArray[i].transform.position;
                equipedGlove = GloveItem[i];
                GloveItem[i] = null;
            }
        }
    }
    public void ApplyShoe()
    {
        ShoeItem[0] = ItemStorage.getShoeSlot()[0];
        changeItemArray();
        for (int i = 0; i < ShoeItem.Length; i++)
        {
            if (ShoeItem[i] != null)
            {
                ShoeItem[i].transform.position = itemArray[i].transform.position;
                equipedShoe = ShoeItem[i];
                ShoeItem[i] = null;
            }
        }
    }
    public void changeItemArray()
    {
        for (int i = 0; i < WeaponItem.Length; i++)
        {//&& !WeaponItem[i].GetComponent<AddEquipment>().getSelect()
            if (WeaponItem[i] != null )
            {
                WeaponItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
        for (int i = 0; i < HeadItem.Length; i++)
        {
            if (HeadItem[i] != null && !HeadItem[i].GetComponent<AddEquipment>().getSelect())
            {
                HeadItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
        for (int i = 0; i < FrontItem.Length; i++)
        {
            if (FrontItem[i] != null && !FrontItem[i].GetComponent<AddEquipment>().getSelect())
            {
                FrontItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
        for (int i = 0; i < BodyItem.Length; i++)
        {
            if (BodyItem[i] != null && !BodyItem[i].GetComponent<AddEquipment>().getSelect())
            {
                BodyItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
        for (int i = 0; i < PantsItem.Length; i++)
        {
            if (PantsItem[i] != null && !PantsItem[i].GetComponent<AddEquipment>().getSelect())
            {
                PantsItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
        for (int i = 0; i < GloveItem.Length; i++)
        {
            if (GloveItem[i] != null && !GloveItem[i].GetComponent<AddEquipment>().getSelect())
            {
                GloveItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
        for (int i = 0; i < ShoeItem.Length; i++)
        {
            if (ShoeItem[i] != null && !ShoeItem[i].GetComponent<AddEquipment>().getSelect())
            {
                ShoeItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
            }
        }
    }
    public void equip(GameObject item, GameObject position)
    {
        item.transform.position = position.transform.position;
    }
}
