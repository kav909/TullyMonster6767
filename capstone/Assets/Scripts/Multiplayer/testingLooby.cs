using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Relay;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class testingLooby : MonoBehaviour
{

    private Lobby hostLooby;
    private Lobby joinedLobby;
    private float heartbeatTimer;
    private float lobbyUpdateTimer;
    private string playerName = "coo";

    private InputField joinCodeInput;
    private Text joinCodeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Start()
    {

        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        Debug.Log("Player Name: " + playerName);

    }

    public void FindUI()
    {
        joinCodeInput = GameObject.Find("codeInput").GetComponent<InputField>();
        joinCodeText = GameObject.Find("code").GetComponent<Text>();
    }

    public async void OnJoinClicked()
    {
        await JoinLobby(joinCodeInput.text);
    }

    public async void OnCreateClicked()
    {
        await CreateLobby();
    }
    public void OnPlayClicked()
    {
        NetworkConnect.Instance.PlayGame();
    }

    private async Task CreateLobby()
    {
        try
        {
            string lobbyName = "MyLobby";
            int maxPLayers = 4;
            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false,
                Player = GetPlayer(),
                Data = new Dictionary<string, DataObject>
                {
                  //  {"GameMode", new DataObject(DataObject.VisibilityOptions.Public, "CaptureTheFlag") },
                   // { "Map", new DataObject(DataObject.VisibilityOptions.Public, "CityScape2") },
                    { "JOIN_CODE", new DataObject(DataObject.VisibilityOptions.Public, "") }

                }
            };
            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPLayers, createLobbyOptions);
            hostLooby = lobby;
            joinedLobby = hostLooby;
            await GetComponent<NetworkConnect>().CreateRelay(lobby.Id);

            joinCodeText.text = "Code: " + lobby.LobbyCode; 
            Debug.Log("Lobby Code: " + lobby.LobbyCode);

           
        }
        catch (LobbyServiceException e)
        {
            Debug.LogException(e);
        }


    }

    private async void Update()
    {
        if (hostLooby != null)
        {

            heartbeatTimer -= Time.deltaTime;
            if (heartbeatTimer < 0f)
            {
                float heartbeatTimerMax = 15;
                heartbeatTimer = heartbeatTimerMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(hostLooby.Id);
            }
        }
        HandleLobbyPollForUpdates();
    }
    private async void ListLobbies()
    {

        try
        {
            QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
            {
                Count = 25,
                Filters = new List<QueryFilter> {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT),
                    new QueryFilter(QueryFilter.FieldOptions.S1,  "CaptureTheFlag", QueryFilter.OpOptions.EQ)
                },
                Order = new List<QueryOrder> {
                        new QueryOrder(false, QueryOrder.FieldOptions.Created)
                    }
            };

            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);

            Debug.Log("Lobbies found: " + queryResponse.Results.Count);
            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
            }
        }
        catch (LobbyServiceException e)
        {
            Debug.LogException(e);
        }
    }

    private async 
    Task
JoinLobby(string lobbyCode)
    {
        try
        {
            JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
            {
                Player = GetPlayer()
            };
            Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(lobbyCode, joinLobbyByCodeOptions);
            joinedLobby = lobby;

            string relayCode = lobby.Data["JOIN_CODE"].Value;
            await GetComponent<NetworkConnect>().JoinRelay(relayCode);

            Debug.Log("Joined Lobby with code: " + lobbyCode);
            joinCodeText.text = "Success! Joined lobby.";
        }
        catch (LobbyServiceException e)
        {
            Debug.LogException(e);
        }
    }
    private async void HandleLobbyPollForUpdates() {
        if (joinedLobby != null)
        {

            lobbyUpdateTimer -= Time.deltaTime;
            if (lobbyUpdateTimer < 0f)
            {
                float lobbyUpdateTimerMax = 1.1f;
                lobbyUpdateTimer = lobbyUpdateTimerMax;

                Lobby lobby = await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);
                joinedLobby = lobby;
            }
        }
    }

    private Unity.Services.Lobbies.Models.Player GetPlayer()
    {
        return new Unity.Services.Lobbies.Models.Player
        {
            Data = new Dictionary<string, PlayerDataObject> {
            { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Public, playerName) }
        }
        };
    }



   // private void PrintPlayer(Lobby lobby) {
       // Debug.Log("Players in LobbY " + lobby.Name);
        //foreach (Player player in lobby.Players) {
        //    Debug.Log(player.Id);
        //}
   // }

    private async Task UpdateLoobyGameMode(string gameMode) {
        try
        {
            hostLooby = await Lobbies.Instance.UpdateLobbyAsync(hostLooby.Id, new UpdateLobbyOptions
            {
                Data = new Dictionary<string, DataObject>
                {
                    {"GameMode", new DataObject(DataObject.VisibilityOptions.Public, gameMode) },
                }
            });
            joinedLobby = hostLooby;

        }
        catch (LobbyServiceException e)
        {
            Debug.LogException(e);
        }
    }

    private async Task UpdatePLayerName(string newName)
    {
        try
        {
            playerName = newName;
           await LobbyService.Instance.UpdatePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId, new UpdatePlayerOptions
            {
                Data = new Dictionary<string, PlayerDataObject> {
            { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Public, playerName) }
        }
            });
        }
        catch (LobbyServiceException e)
        {
            Debug.LogException(e);
        }
    }

    private async Task LeaveLobby()
    {
        try
        {
            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogException(e);
        }
    }

    private async Task KickPlayer() {
        try { 

            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, joinedLobby.Players[1].Id);
        }catch(LobbyServiceException e) {
            Debug.LogException(e);
        }
    }
}

