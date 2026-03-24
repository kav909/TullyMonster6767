using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool isLocked;
    [SerializeField] GameObject ClosedDoor;
    [SerializeField] GameObject OpenDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameObject.tag == "LockedDoor")
        {
            isLocked = true;
        }
        else if(gameObject.tag == "Door")
        {
            isLocked = false;
        }
        OpenDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string DoorIsLocked() ///Give the text that the door is locked
    {
        return "The door seems to be locked.";
    }
    public void OpenTheDoor() /////Open the door
    {
        ClosedDoor.SetActive(false);
        OpenDoor.SetActive(true);
    }
    public bool IsLocked() 
    { 
        return isLocked; 
    }
    public void unLock()
    {
        isLocked = false;
    }
}
