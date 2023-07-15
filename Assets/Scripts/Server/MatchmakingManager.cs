using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;

public class MatchmakingManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
        raiseEventOptions.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(
            ServerEventCodes.PLAYER_ENTERED_ROOM, 
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
            ServerEventCodes.PLAYER_ENTERED_ROOM,
            otherPlayer,
            RaiseEventOptions.Default,
            SendOptions.SendReliable
            );
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void LeaveCurrentRoom()
    {
        PhotonNetwork.LeaveRoom(false);
        PhotonNetwork.LoadLevel("Lobby");
    }
}
