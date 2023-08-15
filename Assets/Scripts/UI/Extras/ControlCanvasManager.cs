using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventData = ExitGames.Client.Photon.EventData;

public class ControlCanvasManager : MonoBehaviour
{
    private PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            gameObject.SetActive(false);
            return;
        }

        PhotonNetwork.NetworkingClient.EventReceived += OnGameEvent;
    }

    private void OnGameEvent(EventData obj)
    {
        if (obj.Code == GameEventCodes.PLAYER_DEATH)
        {
            gameObject.SetActive(false);
        }
    }
}
