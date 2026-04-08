using Unity.VisualScripting;
using UnityEngine;

public class AddEquipment : MonoBehaviour
{
    public bool isSelecting;
    public int AddATK;
    public int AddDEF;
    public int AddSPD;
    public int AddMAG;
    [SerializeField] ItemStorage itemStorage;
    [SerializeField] Equip Equip;
    [SerializeField] GameObject weaponSlot;
    [SerializeField] GameObject headSlot;
    [SerializeField] GameObject frontSlot;
    [SerializeField] GameObject bodySlot;
    [SerializeField] GameObject pantsSlot;
    [SerializeField] GameObject gloveSlot;
    [SerializeField] GameObject shoeSlot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        isSelecting = true;
        if (gameObject.tag == "Weapon")
        {
            weaponSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, weaponSlot);
        }
        if (gameObject.tag == "Head")
        {
            headSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, headSlot);
        }
        if (gameObject.tag == "Front")
        {
            frontSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, frontSlot);
        }
        if (gameObject.tag == "Body")
        {
            bodySlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, bodySlot);
        }
        if (gameObject.tag == "Pants")
        {
            pantsSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, pantsSlot);
        }
        if (gameObject.tag == "Glove")
        {
            gloveSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, gloveSlot);
        }
        if (gameObject.tag == "Shoe")
        {
            shoeSlot.GetComponent<Inventory>().isEquiped(true);
            Equip.equip(gameObject, shoeSlot);
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
}
