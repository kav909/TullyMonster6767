using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class NetworkConnect : MonoBehaviour
{
    public static NetworkConnect Instance;
    public int maxConnections = 20;
    public UnityTransport transport;
    public GameObject playerPrefab;

    void Awake()
    {
       // Instance = this;
        transport = GetComponent<UnityTransport>();
    }

    public async Task CreateRelay(string lobbyId)
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections, "us-central1");
        string newJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        // saves relay code in lobby
        await LobbyService.Instance.UpdateLobbyAsync(lobbyId, new UpdateLobbyOptions
        {
            Data = new Dictionary<string, DataObject>
            {
                { "JOIN_CODE", new DataObject(DataObject.VisibilityOptions.Public, newJoinCode) }
            }
        });

        transport.SetHostRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port, allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData);
        NetworkManager.Singleton.StartHost();
    }

    public async Task JoinRelay(string relayCode)
    {
        JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(relayCode);
        transport.SetClientRelayData(allocation.RelayServer.IpV4, (ushort)allocation.RelayServer.Port, allocation.AllocationIdBytes, allocation.Key, allocation.ConnectionData, allocation.HostConnectionData);
        NetworkManager.Singleton.StartClient();
    }

    public void PlayGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SpawnPlayers;
            NetworkManager.Singleton.SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
    }

    private void SpawnPlayers(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            GameObject player = Instantiate(playerPrefab);
            player.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.ClientId);
        }
        NetworkManager.Singleton.SceneManager.OnLoadEventCompleted -= SpawnPlayers;
    }
}