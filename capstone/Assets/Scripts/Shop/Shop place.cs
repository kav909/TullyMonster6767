using UnityEngine;

public class Shopplace : MonoBehaviour
{
    [SerializeField] ItemStorage ItemStorage;
    float xPosition = -7;
    float yPosition = 2;
    int currentNum = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown(){
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
            ItemStorage.WeaponSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void showHead(){
        for(int i = 0; i < ItemStorage.HeadSlot.Length; i++){
            ItemStorage.HeadSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void showFront(){
        for(int i = 0; i < ItemStorage.FrontSlot.Length; i++){
            ItemStorage.FrontSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void showBody(){
        for(int i = 0; i < ItemStorage.BodySlot.Length; i++){
            ItemStorage.BodySlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void showGlove(){
        for(int i = 0; i < ItemStorage.GloveSlot.Length; i++){
            ItemStorage.GloveSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void showPants(){
        for(int i = 0; i < ItemStorage.PantsSlot.Length; i++){
            ItemStorage.PantsSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void showShoe(){
        for(int i = 0; i < ItemStorage.ShoeSlot.Length; i++){
            ItemStorage.ShoeSlot[i].gameObject.transform.position = new Vector2(xPosition, yPosition);
            xPosition += 3.5f;
            currentNum++;
            if(currentNum >= 5){
                currentNum = 0;
                xPosition = -7f;
                yPosition -= 2f;
            }
        }
    }
    public void refresh(){
        for(int i = 0; i < ItemStorage.WeaponSlot.Length; i++){
            ItemStorage.WeaponSlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }       
        for(int i = 0; i < ItemStorage.HeadSlot.Length; i++){
            ItemStorage.HeadSlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }  
        for(int i = 0; i < ItemStorage.FrontSlot.Length; i++){
            ItemStorage.FrontSlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }  
        for(int i = 0; i < ItemStorage.BodySlot.Length; i++){
            ItemStorage.BodySlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }  
        for(int i = 0; i < ItemStorage.GloveSlot.Length; i++){
            ItemStorage.GloveSlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }  
        for(int i = 0; i < ItemStorage.PantsSlot.Length; i++){
            ItemStorage.PantsSlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }  
        for(int i = 0; i < ItemStorage.ShoeSlot.Length; i++){
            ItemStorage.ShoeSlot[i].gameObject.transform.position = new Vector2(0f, -20f);
        }  
    }
}
