using UnityEngine;
using Unity.Netcode;

public class NetworkConnect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create() { 
        NetworkManager.Singleton.StartHost();
    }

    public void Join() { 
            NetworkManager.Singleton.StartClient();
    }
}
