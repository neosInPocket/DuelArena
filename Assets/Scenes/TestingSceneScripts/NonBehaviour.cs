using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestConnection test = new TestConnection();   
    }
}

public class TestConnection : IConnectionCallbacks
{
    public TestConnection()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }

    public void OnConnected()
    {
        Debug.Log("Connected");
    }

    public void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
    }

    public void OnCustomAuthenticationFailed(string debugMessage)
    {
        throw new System.NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        throw new System.NotImplementedException();
    }

    public void OnDisconnected(DisconnectCause cause)
    {
        throw new System.NotImplementedException();
    }

    public void OnRegionListReceived(RegionHandler regionHandler)
    {
        throw new System.NotImplementedException();
    }
}
