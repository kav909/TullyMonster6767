using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject[] HeadItem = new GameObject[12];
    GameObject[] FrontItem = new GameObject[12];
    GameObject[] BodyItem = new GameObject[12];
    GameObject[] PantsItem = new GameObject[12];
    GameObject[] GloveItem = new GameObject[12];
    GameObject[] ShoeItem = new GameObject[12];
    GameObject[] WeaponItem = new GameObject[12];
    [SerializeField] ItemStorage ItemStorage;
    [SerializeField] GameObject InventoryTab;
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
    void Start()
    {
        InventoryTab.SetActive(false);
        WeaponItem[0] = ItemStorage.getWeaponSlot()[0];
        Debug.Log(WeaponItem[0] + "start ");
        //Debug.Log(" " + WeaponItem[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (gameObject.tag == "Weapon")
        {
            InventoryTab.SetActive(true);
            Debug.Log(ItemStorage.getWeaponSlot()[0]);
            Debug.Log(WeaponItem[0]);
            ApplyWeapon();
        }
    }
    public void ApplyWeapon(){
        for(int i = 0; i < WeaponItem.Length; i++){
            if(WeaponItem[i] != null)
            {
                Debug.Log("changed");
                item1 = WeaponItem[i];
            }
        }
    }
}
