using Newtonsoft.Json;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Equip : MonoBehaviour
{
    [SerializeField] ItemStorage ItemStorage;
    //[SerializeField] levelup levelup;
    public GameObject[] HeadItem = new GameObject[12];
    public GameObject[] FrontItem = new GameObject[12];
    public GameObject[] BodyItem = new GameObject[12];
    public GameObject[] PantsItem = new GameObject[12];
    public GameObject[] GloveItem = new GameObject[12];
    public GameObject[] ShoeItem = new GameObject[12];
    public GameObject[] WeaponItem = new GameObject[12];
    public GameObject[] itemArray = new GameObject[12];
    
    //public GameObject equipedHead;
    //public GameObject equipedFront;
    //public GameObject equipedBody;
    //public GameObject equipedPants;
    //public GameObject equipedGlove;
    //public GameObject equipedShoe;
    //public GameObject equipedWeapon;

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
        DontDestroyOnLoad(gameObject);
        foreach (var obj in WeaponItem)
        {
            Debug.Log("AAAAA");

            if (obj != null)
            {
                Debug.Log("There are weapon in here");
                DontDestroyOnLoad(obj);
            }

        }

        if (ItemStorage == null)
        {
             ItemStorage = FindAnyObjectByType<ItemStorage>();
        }

        if (ItemStorage == null)
        {
            Debug.LogError("ItemStorage not found in scene!");
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)   ///<<--- 
    {
        ItemStorage = FindAnyObjectByType<ItemStorage>();
        

    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
        WeaponItem[findOpenWeaponIndex()] = ItemStorage.getWeaponSlot()[0];
        WeaponItem[findOpenWeaponIndex()] = ItemStorage.getWeaponSlot()[1];
        HeadItem[findOpenHeadIndex()] = ItemStorage.getHeadSlot()[0];
        FrontItem[findOpenFrontIndex()] = ItemStorage.getFrontSlot()[0];
        BodyItem[findOpenBodyIndex()] = ItemStorage.getBodySlot()[0];
        PantsItem[findOpenPantsIndex()] = ItemStorage.getPantsSlot()[0];
        GloveItem[findOpenGloveIndex()] = ItemStorage.getGloveSlot()[0];
        ShoeItem[findOpenShoeIndex()] = ItemStorage.getShoeSlot()[0];
        Debug.Log("finish adding");
        printWeaponSlot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            printWeaponSlot();
        }
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
        //WeaponItem[0] = ItemStorage.getWeaponSlot()[0];
        //WeaponItem[1] = ItemStorage.getWeaponSlot()[1];
        changeItemArray();
        for (int i = 0; i < WeaponItem.Length; i++)
        {
            if (WeaponItem[i] != null)
            {
                if (WeaponItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    WeaponItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                WeaponItem[i].GetComponent<AddEquipment>().undoSelect();
                WeaponItem[i].transform.position = itemArray[i].transform.position;
                //equipedWeapon = WeaponItem[i];
                //WeaponItem[i] = null;
            }            
        }
    }
    public void ApplyHead()
    {
        //HeadItem[0] = ItemStorage.getHeadSlot()[0];
        changeItemArray();
        for (int i = 0; i < HeadItem.Length; i++)
        {
            if (HeadItem[i] != null)
            {
                if (HeadItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    HeadItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                HeadItem[i].GetComponent<AddEquipment>().undoSelect();
                HeadItem[i].transform.position = itemArray[i].transform.position;
                //equipedHead = HeadItem[i];
                //HeadItem[i] = null;
            }
        }
    }
    public void ApplyFront()
    {
        //FrontItem[0] = ItemStorage.getFrontSlot()[0];
        changeItemArray();
        for (int i = 0; i < FrontItem.Length; i++)
        {
            if (FrontItem[i] != null)
            {
                if (FrontItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    FrontItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                FrontItem[i].GetComponent<AddEquipment>().undoSelect();
                FrontItem[i].transform.position = itemArray[i].transform.position;
                //equipedFront = FrontItem[i];
                //FrontItem[i] = null;
            }
        }
    }
    public void ApplyBody()
    {
        //BodyItem[0] = ItemStorage.getBodySlot()[0];
        changeItemArray();
        for (int i = 0; i < BodyItem.Length; i++)
        {
            if (BodyItem[i] != null)
            {
                if (BodyItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    BodyItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                BodyItem[i].GetComponent<AddEquipment>().undoSelect();
                BodyItem[i].transform.position = itemArray[i].transform.position;
                //equipedBody = BodyItem[i];
                //BodyItem[i] = null;
            }
        }
    }
    public void ApplyPants()
    {
        //PantsItem[0] = ItemStorage.getPantsSlot()[0];
        changeItemArray();
        for (int i = 0; i < PantsItem.Length; i++)
        {
            if (PantsItem[i] != null)
            {
                if (PantsItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    PantsItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                PantsItem[i].GetComponent<AddEquipment>().undoSelect();
                PantsItem[i].transform.position = itemArray[i].transform.position;
                //equipedPants = PantsItem[i];
                //PantsItem[i] = null;
            }
        }
    }
    public void ApplyGlove()
    {
        //GloveItem[0] = ItemStorage.getGloveSlot()[0];
        changeItemArray();
        for (int i = 0; i < GloveItem.Length; i++)
        {
            if (GloveItem[i] != null)
            {
                if (GloveItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    GloveItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                GloveItem[i].GetComponent<AddEquipment>().undoSelect();
                GloveItem[i].transform.position = itemArray[i].transform.position;
                //equipedGlove = GloveItem[i];
                //GloveItem[i] = null;
            }
        }
    }
    public void ApplyShoe()
    {
        //ShoeItem[0] = ItemStorage.getShoeSlot()[0];
        changeItemArray();
        for (int i = 0; i < ShoeItem.Length; i++)
        {
            //Debug.Log("Shoe Items are: " + ShoeItem[i]);
            if (ShoeItem[i] != null)
            {
                if (ShoeItem[i].GetComponent<AddEquipment>().getSelect())
                {
                    ShoeItem[i].GetComponent<AddEquipment>().unequipStats();
                }
                ShoeItem[i].GetComponent<AddEquipment>().undoSelect();
                ShoeItem[i].transform.position = itemArray[i].transform.position;
                //equipedShoe = ShoeItem[i];
                //ShoeItem[i] = null;
            }
        }
    }
    public void changeItemArray()//
    {
        for (int i = 0; i < WeaponItem.Length; i++)
        {//&& !WeaponItem[i].GetComponent<AddEquipment>().getSelect()
            if (WeaponItem[i] != null )
            {
                if(!WeaponItem[i].GetComponent<AddEquipment>().getSelect()){
                    WeaponItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
        for (int i = 0; i < HeadItem.Length; i++)
        {
            if (HeadItem[i] != null)
            {
                if(!HeadItem[i].GetComponent<AddEquipment>().getSelect()){
                    HeadItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
        for (int i = 0; i < FrontItem.Length; i++)
        {
            if (FrontItem[i] != null)
            {
                if(!FrontItem[i].GetComponent<AddEquipment>().getSelect()){
                    FrontItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
        for (int i = 0; i < BodyItem.Length; i++)
        {
            if (BodyItem[i] != null)
            {
                if(!BodyItem[i].GetComponent<AddEquipment>().getSelect()){
                    BodyItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
        for (int i = 0; i < PantsItem.Length; i++)
        {
            if (PantsItem[i] != null)
            {
                if(!PantsItem[i].GetComponent<AddEquipment>().getSelect()){
                    PantsItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
        for (int i = 0; i < GloveItem.Length; i++)
        {
            if (GloveItem[i] != null)
            {
                if(!GloveItem[i].GetComponent<AddEquipment>().getSelect()){
                    GloveItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
        for (int i = 0; i < ShoeItem.Length; i++)
        {
            // !ShoeItem[i].GetComponent<AddEquipment>().getSelect()
            if (ShoeItem[i] != null)
            {
                if(!ShoeItem[i].GetComponent<AddEquipment>().getSelect()){
                    ShoeItem[i].transform.position = new Vector2(0.5519999f, -16.014f);
                    
                }
            }
        }
    }
    public void equip(GameObject item, GameObject position)
    {
        item.transform.position = position.transform.position;
    }
    public void pickUpFindCatagory(GameObject equipment){
        //Debug.Log("a");
        if(equipment.tag == "Weapon"){
            for(int i = 0; i < ItemStorage.getWeaponSlot().Length; i++){
                if(equipment == ItemStorage.getWeaponSlot()[i]){
                    //Debug.Log("the open index is " + findOpenWeaponIndex());
                    //Debug.Log("b");
                    WeaponItem[findOpenWeaponIndex()] = equipment;
                }
            }
        }
    }
    public int findOpenWeaponIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < WeaponItem.Length; i++){
            //Debug.Log("c");
            if(WeaponItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public int findOpenHeadIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < HeadItem.Length; i++){
            //Debug.Log("c");
            if(HeadItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public int findOpenFrontIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < FrontItem.Length; i++){
            //Debug.Log("c");
            if(FrontItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public int findOpenBodyIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < BodyItem.Length; i++){
            //Debug.Log("c");
            if(BodyItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public int findOpenPantsIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < PantsItem.Length; i++){
            //Debug.Log("c");
            if(PantsItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public int findOpenGloveIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < GloveItem.Length; i++){
            //Debug.Log("c");
            if(GloveItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public int findOpenShoeIndex(){
        bool hasEmptySlot = false;
        for(int i = 0; i < ShoeItem.Length; i++){
            //Debug.Log("c");
            if(ShoeItem[i] == null){
                //Debug.Log("d");
                //Debug.Log("the open index is " + i);
                hasEmptySlot = true;
                return i;
            }
        }
        return -1;
    }
    public void printWeaponSlot(){
        for(int i = 0; i < WeaponItem.Length; i++){
            if(WeaponItem[i] != null){
                Debug.Log(WeaponItem[i] + "\n");
            }
            else{
                Debug.Log("The rest is Null");
                break;
            }
        }
    }
    public GameObject[] GetWeaponArray()
    {
        return WeaponItem;
    }
}
