using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using WebSocketSharp;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomNameText;

    public string RoomName => roomNameText.text;

    private RoomOptions currentRoomOptions;
    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            GameEvent.RaiseEvent(GameEventCodes.ERROR, "Check your internet connection");
            return;
        }

        if (RoomName.IsNullOrEmpty() || RoomName.Length > 25)
        {
            GameEvent.RaiseEvent(GameEventCodes.ERROR, "Room name cannot be empty and has to contain less than 25 symbols");
            return;
        }

        if (PhotonNetwork.LocalPlayer.NickName.IsNullOrEmpty()) 
        {
            GameEvent.RaiseEvent(GameEventCodes.ERROR, "You must first enter your nickname in the settings");
            return;
        }

        currentRoomOptions = new RoomOptions();
        currentRoomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(RoomName, currentRoomOptions, TypedLobby.Default);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        GameEvent.RaiseEvent(GameEventCodes.ERROR, message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        GameEvent.RaiseEvent(GameEventCodes.ERROR, message);
    }
}
