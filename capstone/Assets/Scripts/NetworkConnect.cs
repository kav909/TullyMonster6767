using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NetworkConnect : MonoBehaviour
{
    public int maxConnections = 20;
    public UnityTransport transport;
    public string joinCode;

    private float heartbeatTimer;
    public Text text;
    

    private Lobby currentLobby;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        JoinOrCreate();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         heartbeatTimer += Time.deltaTime;
         if (heartbeatTimer > 15) {
             heartbeatTimer -= 15;

             if(currentLobby != null && currentLobby.HostId == AuthenticationService.Instance.PlayerId) {
                 LobbyService.Instance.SendHeartbeatPingAsync(currentLobby.Id);
             }
         }
    }

    public async void JoinOrCreate()
    {
        try
        {
            currentLobby = await Lobbies.Instance.QuickJoinLobbyAsync();

            string relayJoinCode = currentLobby.Data["JOIN_CODE"].Value;
            JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(relayJoinCode);

            transport.SetClientRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port, allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData, allocation.HostConnectionData);

            NetworkManager.Singleton.StartClient();
        }
        catch (LobbyServiceException e)
        {
            Create();
        }
    }

    public async void Create()
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
        string newJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        Debug.Log("Jion Code: " + newJoinCode);
        text.text = "Join Code: " + newJoinCode;
        transport.SetHostRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port, allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData);
        currentLobby = await LobbyService.Instance.CreateLobbyAsync("Lobby Name", maxConnections);
         CreateLobbyOptions lobbyOptions = new CreateLobbyOptions(); 
        lobbyOptions.IsPrivate =false;
        lobbyOptions.Data = new  Dictionary<string, DataObject>();
        DataObject dataObject = new DataObject(DataObject.VisibilityOptions.Public, newJoinCode);
         lobbyOptions.Data.Add("JOIN_CODE", dataObject);

         currentLobby = await Lobbies.Instance.CreateLobbyAsync("Lobby Name", maxConnections, lobbyOptions);

        NetworkManager.Singleton.StartHost();
    }

    public async void Join()
    {

         currentLobby = await Lobbies.Instance.QuickJoinLobbyAsync();

        string relayJoinCode = currentLobby.Data["JOIN_CODE"].Value;
        
        JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(relayJoinCode);

        transport.SetClientRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port, allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData, allocation.HostConnectionData);

        NetworkManager.Singleton.StartClient();
    }

    public void PlayGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("shop", LoadSceneMode.Single);
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("shop", LoadSceneMode.Single);
        }
    }
}
