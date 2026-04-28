using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryTab;
    [SerializeField] Equip equip;
    public bool containEquipment;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        InventoryTab = GameObject.Find("Inventory Tab");
        equip = InventoryTab.GetComponent<Equip>();
    }
    void Start()
    {
        
        InventoryTab.SetActive(false);
        //InventoryTab.GetComponent<SpriteRenderer>().enabled = false;
        
        //Debug.Log(" " + WeaponItem[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
       // if (!containEquipment)
        //{
        containEquipment = false;
        InventoryTab.transform.position = new Vector2(-2.08f, -2.4f);
        InventoryTab.SetActive(true);
        if (gameObject.tag == "WeaponItem")
            {
                Debug.Log("weapon");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.orange;
                //InventoryTab.SetActive(true);
                equip.ApplyWeapon();
            }
            if (gameObject.tag == "HeadItem")
            {
                Debug.Log("head");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.red;
                //InventoryTab.SetActive(true);
                equip.ApplyHead();
            }
            if (gameObject.tag == "FrontItem")
            {
                Debug.Log("front");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.purple;
                //InventoryTab.SetActive(true);
                equip.ApplyFront();
            }
            if (gameObject.tag == "BodyItem")
            {
                Debug.Log("body");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.blue;
                //InventoryTab.SetActive(true);
                equip.ApplyBody();
            }
            if (gameObject.tag == "PantsItem")
            {
                Debug.Log("pants");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.cyan;
                //InventoryTab.SetActive(true);
                equip.ApplyPants();
            }
            if (gameObject.tag == "GloveItem")
            {
                Debug.Log("glove");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.green;
                //InventoryTab.SetActive(true);
                equip.ApplyGlove();
            }
            if (gameObject.tag == "ShoeItem")
            {
                Debug.Log("shoe");
                InventoryTab.GetComponent<SpriteRenderer>().color = Color.yellow;
                //InventoryTab.SetActive(true);
                equip.ApplyShoe();
            }
        //}
       /* else
        {
            if (gameObject.tag == "Weapon")
            {
                
            }
            if (gameObject.tag == "Head")
            {
                InventoryTab.SetActive(true);
                equip.ApplyHead();
            }
            if (gameObject.tag == "Front")
            {
                InventoryTab.SetActive(true);
                equip.ApplyFront();
            }
            if (gameObject.tag == "Body")
            {
                InventoryTab.SetActive(true);
                equip.ApplyBody();
            }
            if (gameObject.tag == "Pants")
            {
                InventoryTab.SetActive(true);
                equip.ApplyPants();
            }
            if (gameObject.tag == "Glove")
            {
                InventoryTab.SetActive(true);
                equip.ApplyGlove();
            }
            if (gameObject.tag == "Shoe")
            {
                InventoryTab.SetActive(true);
                equip.ApplyShoe();
            }
        }*/
    }
    public void OnTriggerEnter2D(Collider2D equipment)
    {
        if(equipment.gameObject.tag == "Weapon"){
            containEquipment = true;
        }
    }
    public void isEquiped(bool ISit)
    {
        containEquipment = ISit;
    }
}
