using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        
    }

    public void Pk()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public void Leave()
    {
        print(PhotonNetwork.LeaveRoom());
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        print("new master client");
    }
}
