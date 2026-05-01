using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shopplace : MonoBehaviour
{
    [SerializeField] ItemStorage ItemStorage;
    [SerializeField] PriceManager manager;
    public List<GameObject> itemList;
    float xPosition = -7;
    float yPosition = 2;
    int currentNum = 0;
    public static Shopplace Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //Destroy(gameObject); // destroy duplicate
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

       
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        ItemStorage = GameObject.Find("ItemStorage").GetComponent<ItemStorage>();
        // itemStorage.FindAnyObjectByType<ItemStorage>();
        // itemStorage.GameObject.Find("ItemStorage")
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown(){
        manager.isRefresh = true;
        refresh();
        xPosition = -7f;
        yPosition = 2f;
        currentNum = 0;
        if(gameObject.tag == "WeaponItem"){
            showWeapon();
            Debug.Log("Buy Weapon");
        }
        if(gameObject.tag == "HeadItem"){
            showHead();
            Debug.Log("Buy Head");
        }
        if(gameObject.tag == "FrontItem"){
            showFront();
            Debug.Log("Buy Front");
        }
        if(gameObject.tag == "BodyItem"){
            showBody();
            Debug.Log("Buy Body");
        }
        if(gameObject.tag == "GloveItem"){
            showGlove();
            Debug.Log("Buy Glove");
        }
        if(gameObject.tag == "PantsItem"){
            showPants();
            Debug.Log("Buy Pants");
        }
        if(gameObject.tag == "ShoeItem"){
            showShoe();
            Debug.Log("Buy Shoe");
        }
    }
    public void showWeapon(){
        for(int i = 0; i < ItemStorage.WeaponSlot.Length; i++){
            if (ItemStorage.WeaponSlot[i] != null)
            {
                ItemStorage.WeaponSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.WeaponSlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void showHead(){
        for(int i = 0; i < ItemStorage.HeadSlot.Length; i++){
            if (ItemStorage.HeadSlot[i] != null)
            {
                ItemStorage.HeadSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.HeadSlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void showFront(){
        for(int i = 0; i < ItemStorage.FrontSlot.Length; i++){
            if (ItemStorage.FrontSlot[i] != null)
            {
                ItemStorage.FrontSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.FrontSlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void showBody(){
        for(int i = 0; i < ItemStorage.BodySlot.Length; i++){
            if (ItemStorage.BodySlot[i] != null)
            {
                ItemStorage.BodySlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.BodySlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void showGlove(){
        for(int i = 0; i < ItemStorage.GloveSlot.Length; i++){
            if (ItemStorage.GloveSlot[i] != null)
            {
                ItemStorage.GloveSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.GloveSlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void showPants(){
        for(int i = 0; i < ItemStorage.PantsSlot.Length; i++){
            if (ItemStorage.PantsSlot[i] != null)
            {
                ItemStorage.PantsSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.PantsSlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void showShoe(){
        for(int i = 0; i < ItemStorage.ShoeSlot.Length; i++){
            if (ItemStorage.ShoeSlot[i] != null)
            {
                ItemStorage.ShoeSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
                GameObject textObj = new GameObject("MyText");
                textObj.transform.SetParent(GameObject.Find("ShopCanvas").transform);
                TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
                text.text = "Price: " + ItemStorage.ShoeSlot[i].GetComponent<AddEquipment>().getPrice();
                text.fontSize = 0.4f;
                textObj.transform.position = new Vector2(xPosition + 100.4f, yPosition - 24.75f);
                manager.addPrice(textObj);
                xPosition += 3.5f;
                currentNum++;
                if (currentNum >= 5)
                {
                    currentNum = 0;
                    xPosition = -7f;
                    yPosition -= 2f;
                }
            }
        }
    }
    public void refresh(){
        for(int i = 0; i < ItemStorage.WeaponSlot.Length; i++){
            if (ItemStorage.WeaponSlot[i] != null)
            {
                ItemStorage.WeaponSlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
            
        }       
        for(int i = 0; i < ItemStorage.HeadSlot.Length; i++){
            if (ItemStorage.HeadSlot[i] != null)
            {
                ItemStorage.HeadSlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
            
        }  
        for(int i = 0; i < ItemStorage.FrontSlot.Length; i++){
            if (ItemStorage.FrontSlot[i] != null)
            {
                ItemStorage.FrontSlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
            
        }  
        for(int i = 0; i < ItemStorage.BodySlot.Length; i++){
            if (ItemStorage.BodySlot[i] != null)
            {
                ItemStorage.BodySlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
            
        }  
        for(int i = 0; i < ItemStorage.GloveSlot.Length; i++){
            if (ItemStorage.GloveSlot[i] != null)
            {
                ItemStorage.GloveSlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
            
        }  
        for(int i = 0; i < ItemStorage.PantsSlot.Length; i++){
            if (ItemStorage.PantsSlot[i] != null)
            {
                ItemStorage.PantsSlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
            
        }  
        for(int i = 0; i < ItemStorage.ShoeSlot.Length; i++){
            if (ItemStorage.ShoeSlot[i] != null)
            {
                ItemStorage.ShoeSlot[i].gameObject.transform.position = new Vector2(0f, -60f);
            }
        }
        manager.removePrice();
    }
}
