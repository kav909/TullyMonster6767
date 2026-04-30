using UnityEngine;

public class BuyEquipment : MonoBehaviour
{
    [SerializeField] Equip Equip;
    [SerializeField] PriceManager manager;
    [SerializeField] ItemStorage itemStorage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        Debug.Log("Buy Weapon");
        if (gameObject.tag == "Weapon")
        {
            int x = Equip.findOpenWeaponIndex();
            Equip.WeaponItem[Equip.findOpenWeaponIndex()] = gameObject;
           // itemStorage.weaponSlot  <----Figure out a way to know which index to set null
            Debug.Log(Equip.WeaponItem[x]);
        }
        if (gameObject.tag == "Head")
        {
            Equip.HeadItem[Equip.findOpenHeadIndex()] = gameObject;
        }
        if (gameObject.tag == "Front")
        {
            Equip.FrontItem[Equip.findOpenFrontIndex()] = gameObject;
        }
        if (gameObject.tag == "Body")
        {
            Equip.BodyItem[Equip.findOpenBodyIndex()] = gameObject;
        }
        if (gameObject.tag == "Pants")
        {
            Equip.PantsItem[Equip.findOpenPantsIndex()] = gameObject;
        }
        if (gameObject.tag == "Glove")
        {
            Equip.GloveItem[Equip.findOpenGloveIndex()] = gameObject;
        }
        if (gameObject.tag == "Shoe")
        {
            Equip.ShoeItem[Equip.findOpenShoeIndex()] = gameObject;
        }
    }
}
