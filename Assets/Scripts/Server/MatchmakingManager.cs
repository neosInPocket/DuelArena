using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;

public class MatchmakingManager : MonoBehaviourPunCallbacks
{
    [SerializeField] bool skipFullRoom;
    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (skipFullRoom)
        {
            InitPlayersData();
            PhotonNetwork.LoadLevel(2);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
        raiseEventOptions.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(
            GameEventCodes.PLAYER_ENTERED_ROOM, 
            newPlayer,
            raiseEventOptions, 
            SendOptions.SendReliable
            );
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
        raiseEventOptions.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(
            GameEventCodes.PLAYER_ENTERED_ROOM,
            otherPlayer,
            raiseEventOptions,
            SendOptions.SendReliable
            );
    }

    public void StartGame()
    {
        InitPlayersData();
        PhotonNetwork.LoadLevel("Game");
    }

    public void LeaveCurrentRoom()
    {
        PhotonNetwork.LeaveRoom(false);
        PhotonNetwork.LoadLevel("Lobby");
    }

    private void InitPlayersData()
    {
        foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            player.CustomProperties["SpawnPoint"] = Vector3.zero;
            player.CustomProperties["Coins"] = 0;
        }
    }
}
