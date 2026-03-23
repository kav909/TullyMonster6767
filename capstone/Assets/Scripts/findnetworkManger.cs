using UnityEngine;
using UnityEngine.UI;

public class findnetworkManager : MonoBehaviour
{
    [SerializeField] InputField joinCodeInput;
    private NetworkConnect networkConnect;

    void Start()
    {
        networkConnect = FindObjectOfType<NetworkConnect>();
        networkConnect.text = GameObject.Find("code").GetComponent<Text>();
    }

    public void create()
    {
        networkConnect.Create();
    }

    public void join()
    {
        networkConnect.joinCode = joinCodeInput.text;
        networkConnect.Join();
    }

    public void play()
    {
        networkConnect.PlayGame();
    }
}