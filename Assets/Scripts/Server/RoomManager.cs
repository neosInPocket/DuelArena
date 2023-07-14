using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomEnterField;
    [SerializeField] TMP_InputField roomCreateField;

    RoomOptions currentRoomOptions;
    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        
        currentRoomOptions = new RoomOptions();
        currentRoomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomCreateField.text, currentRoomOptions, TypedLobby.Default);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomEnterField.text);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Loading");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room" + message);
        ErrorEvent.Instance.RaiseError(message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join the room" + message);
        ErrorEvent.Instance.RaiseError(message);
    }
}
