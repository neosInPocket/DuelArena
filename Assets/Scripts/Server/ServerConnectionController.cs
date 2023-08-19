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
        
    }

    public void ConnectToServer()
    {
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

     


}
