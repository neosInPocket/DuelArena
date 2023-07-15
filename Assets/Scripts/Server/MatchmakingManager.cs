using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;

public class MatchmakingManager : MonoBehaviourPunCallbacks
{
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player " + newPlayer.NickName + " entered the room");
        PhotonNetwork.RaiseEvent(
            ServerEventCodes.PLAYER_ENTERED_ROOM, 
            Global.GetPlayerInfo(newPlayer), 
            RaiseEventOptions.Default, 
            SendOptions.SendUnreliable
            );
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player " + otherPlayer.NickName + " left the room");
        PhotonNetwork.RaiseEvent(
            ServerEventCodes.PLAYER_ENTERED_ROOM,
            Global.GetPlayerInfo(otherPlayer),
            RaiseEventOptions.Default,
            SendOptions.SendUnreliable
            );
    }
}
