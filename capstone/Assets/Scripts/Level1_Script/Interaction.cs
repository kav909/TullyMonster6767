using Unity.Services.Lobbies.Models;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] GoBackFromShop goBackFromShop;
    [SerializeField] Equip equip;
    [SerializeField] GameObject lootEquipment;
    [SerializeField] GameObject ConversationTab;
    //[SerializeField] TestingScript TestingScript;
    [SerializeField] Text Text;
    [SerializeField] GameObject textWindow;
    [SerializeField] Text StateText;
    [SerializeField] LockedDoor LockedDoor;
    [SerializeField] Chest Chest;
    [SerializeField] Text Money;
    public bool interactable;
    [SerializeField] TextStorage storage;
    public bool haveKey;
    public bool talking;
    public bool hasPickUpEquip;
    public bool isInShop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //textWindow = TestingScript.getTheTextWindow();
        hasPickUpEquip = false;
        talking = false;
        haveKey = false;
        ConversationTab.SetActive(false);
        Text.enabled = false;
        textWindow.SetActive(false);
        StateText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Money = GameObject.Find("Money").GetComponent<Text>();
        equip = FindAnyObjectByType<Equip>();
        if (interactable && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(ConversationTab.tag);
            if(ConversationTab.tag  == "Statue" && !haveKey)
            {
                textWindow.SetActive(true);
                StateText.text = storage.StatueTextLevel1NoKey();
                StateText.enabled = true;
                talking = true;
            }
            else if(ConversationTab.tag == "Statue" && haveKey)
            {
                textWindow.SetActive(true);
                StateText.text = storage.StatueTextLevel1HaveKey();
                StateText.enabled = true;
            }
            
            if (ConversationTab.tag == "Stone Stele")
            {
                textWindow.SetActive(true);
                StateText.text = storage.StoneSteleLevel1();
                StateText.enabled = true;
            }
            if (ConversationTab.tag == "Sign1")
            {
                textWindow.SetActive(true);
                StateText.text = storage.SignsLevel1();
                StateText.enabled = true;
            }
            if (ConversationTab.tag == "Door1")
            {
                if (LockedDoor.IsLocked())
                {
                    textWindow.SetActive(true);
                    StateText.text = LockedDoor.DoorIsLocked();
                    StateText.enabled = true;
                }
                else
                {
                    LockedDoor.OpenTheDoor();
                }
            }
            if (ConversationTab.tag == "NPC Shop")
            {
                textWindow.SetActive(true);
                StateText.text = storage.Shop();
                StateText.enabled = true;
                talking = true;
            }
            if (ConversationTab.tag == "Chest1")
            {
                Chest.OpenChest("Chest1");
            }
            if (ConversationTab.tag == "Chest2")
            {
                Chest.OpenChest("Chest2");
            }
            if (!hasPickUpEquip)
            {
                if (ConversationTab.tag == "PickUpEquipment")
                {
                    Destroy(gameObject);
                    equip.printWeaponSlot();
                    equip.pickUpFindCatagory(lootEquipment);
                    equip.printWeaponSlot();
                    hasPickUpEquip = true;
                    lootEquipment.transform.position = new Vector2(0.5519999f, -16.014f);
                }
            }
            
        }
        if (talking && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("dgsfds");
            StateText.text = storage.ReciveKey();
            haveKey = true;
            LockedDoor.unLock();
        }
        if (talking && Input.GetKeyDown(KeyCode.E))
        {
            isInShop = true;
            //Scene targetScene = SceneManager.GetSceneByName("Shop");
            //SceneManager.SetActiveScene(targetScene);
            goBackFromShop.goToShop();
            Money.gameObject.transform.position = new Vector2(0f, 195.5f);
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Chest.IsChest1Taken() || Chest.IsChest2Taken())
        {
            return;
        }
        ConversationTab.SetActive(true);
        Text.enabled = true;
        interactable = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Chest.IsChest1Taken() || Chest.IsChest2Taken())
        {
            return;
        }
        ConversationTab.SetActive(false);
        Text.enabled = false;
        interactable = false;
        textWindow.SetActive(false);
        StateText.enabled = false;
        talking = false;
    }
    public GameObject getConversationTab()
    {
        return ConversationTab;
    }
    public bool getInteractable()
    {
        return interactable;
    }
    
}
