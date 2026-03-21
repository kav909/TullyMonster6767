using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public bool interactable;
    [SerializeField] GameObject chest1;
    [SerializeField] GameObject openChest1;
    [SerializeField] GameObject Chest1C;
    [SerializeField] GameObject chest2;
    [SerializeField] GameObject openChest2;
    [SerializeField] GameObject Chest2C;
    [SerializeField] Text Text;
    public bool isChest1Taken;
    public bool isChest2Taken;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ConversationTab.SetActive(false);
        Text.enabled = false;
        isChest1Taken = false;
        isChest2Taken = false;
        openChest1.SetActive(false);
        openChest2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }// && collision.tag == "Chest2Range"
    
    public void OpenChest(string chestTag)
    {
        if (chestTag == "Chest1")
        {
            openChest1.SetActive(true);
            chest1.SetActive(false);
            Destroy(Chest1C);
            Destroy(Text);
            //Text.enabled = false;
            isChest1Taken = true;
        }
        if (chestTag == "Chest2")
        {
            openChest2.SetActive(true);
            chest2.SetActive(false);
            Destroy(Chest2C);
            Destroy(Text);
            //Text.enabled = false;
            isChest2Taken = true;
        }
    }
    public bool IsChest1Taken()
    {
        return isChest1Taken;
    }
    public bool IsChest2Taken()
    {
        return isChest2Taken;
    }
}
