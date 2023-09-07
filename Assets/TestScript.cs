using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TestScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private TEstUI ui; 
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        ui.Write("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("room");
        ui.Write("Created room");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("room");
        ui.Write("Joined room");
    }

    public void LoadScene()
    {
        ui.Write("On scene load");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        ui.Write("New player entered the room");
    }
}
