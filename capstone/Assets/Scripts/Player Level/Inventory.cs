using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject[] HeadItem = new GameObject[6];
    GameObject[] FrontItem = new GameObject[8];
    GameObject[] BodyItem = new GameObject[6];
    GameObject[] PantsItem = new GameObject[6];
    GameObject[] GloveItem = new GameObject[6];
    GameObject[] ShoeItem = new GameObject[6];
    GameObject[] WeaponItem = new GameObject[9];
    [SerializeField] ItemStorage ItemStorage;
    [SerializeField] GameObject InventoryTab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryTab.SetActive(false);
        Debug.Log(ItemStorage.getWeaponSlot());
        //WeaponItem[0] = ItemStorage.getWeaponSlot()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PrintWeaponSlots();
        }
    }
    private void OnMouseDown()
    {
        InventoryTab.SetActive(true);
        if (gameObject.tag == "Weapon")
        {
            Debug.Log("Weapon");
        }
    }
    void PrintWeaponSlots()
    {
        for (int i = 0; i < WeaponItem.Length; i++)
        {
            if (WeaponItem[i] != null)
                Debug.Log("Slot " + i + ": " + WeaponItem[i].name);
            else
                Debug.Log("Slot " + i + ": EMPTY");
        }
    }
}
