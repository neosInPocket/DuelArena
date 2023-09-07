using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;
using Photon.Realtime;

public class ServerConnectionController : MonoBehaviourPunCallbacks
{
    void Start()
    {
        ConnectToServer();
    }

    public void ConnectToServer()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master " + PhotonNetwork.CloudRegion);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected " + cause.ToString());
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var room in roomList)
        {
            print(room.Name);
        };
    }

    public void Connectttt()
    {
        var test = new TestScript();
    }
}
