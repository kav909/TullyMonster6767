using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class testingLooby : NetworkBehavior
{

    private Lobby hostLooby;
    private float heartbeatTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Start() {

        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

    }

    private async Task CreateLobby() {
        try
        {
            string lobbyName = "MyLobby";
            int maxPLayers = 4;

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPLayers);

        }
        catch (LobbyServiceException e) {
            Debug.LogException(e);
        }


    }
    private async void ListLobbies() {

        try
        {
            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();
        }
        catch(LobbyServiceException e) {
            Debug.LogException(e);
        }
    }

    
}
