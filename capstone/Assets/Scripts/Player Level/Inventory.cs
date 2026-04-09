using System.ComponentModel;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryTab;
    [SerializeField] Equip equip;
    public bool containEquipment;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        InventoryTab.SetActive(true);
        if (gameObject.tag == "WeaponItem")
            {
                Debug.Log("weapon");
            //InventoryTab.SetActive(true);
                equip.ApplyWeapon();
            }
            if (gameObject.tag == "HeadItem")
            {
                Debug.Log("head");
                //InventoryTab.SetActive(true);
                equip.ApplyHead();
            }
            if (gameObject.tag == "FrontItem")
            {
                Debug.Log("front");
                //InventoryTab.SetActive(true);
                equip.ApplyFront();
            }
            if (gameObject.tag == "BodyItem")
            {
                Debug.Log("body");
                //InventoryTab.SetActive(true);
                equip.ApplyBody();
            }
            if (gameObject.tag == "PantsItem")
            {
                Debug.Log("pants");
                //InventoryTab.SetActive(true);
                equip.ApplyPants();
            }
            if (gameObject.tag == "GloveItem")
            {
                Debug.Log("glove");
                //InventoryTab.SetActive(true);
                equip.ApplyGlove();
            }
            if (gameObject.tag == "ShoeItem")
            {
                Debug.Log("shoe");
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
    public void isEquiped(bool ISit)
    {
        containEquipment = ISit;
    }
}
