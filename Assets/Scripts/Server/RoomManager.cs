using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomEnterField;
    [SerializeField] TMP_InputField roomCreateField;

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomCreateField.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel("Loading");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomEnterField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Loading");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
    }
}
