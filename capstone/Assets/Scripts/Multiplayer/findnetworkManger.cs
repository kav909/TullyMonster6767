using UnityEngine;
using UnityEngine.UI;

public class findnetworkManager : MonoBehaviour
{
    [SerializeField] InputField joinCodeInput;
    private NetworkConnect networkConnect;

    void Start()
    {
        FindObjectOfType<testingLooby>().FindUI();
    }
}