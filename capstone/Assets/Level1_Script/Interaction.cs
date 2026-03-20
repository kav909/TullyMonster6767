using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject ConversationTab;
    [SerializeField] Text Text;
    [SerializeField] GameObject textWindow;
    [SerializeField] Text StateText;
    public bool interactable;
    [SerializeField] TextStorage storage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConversationTab.SetActive(false);
        Text.enabled = false;
        textWindow.SetActive(false);
        StateText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(ConversationTab.tag);
            if(ConversationTab.tag  == "Statue")
            {
                textWindow.SetActive(true);
                StateText.text = storage.StatueTextLevel1();
                StateText.enabled = true;
            }
            if(ConversationTab.tag == "Stone Stele")
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ConversationTab.SetActive(true);
        Text.enabled = true;
        interactable = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ConversationTab.SetActive(false);
        Text.enabled = false;
        interactable = false;
        textWindow.SetActive(false);
        StateText.enabled = false;
    }
}
