using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServerController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();

        Player currentPlayer = PhotonNetwork.LocalPlayer;
        Color playerColor = PlayerManager.GetPlayerColor(currentPlayer);
        GetComponent<SpriteRenderer>().color = playerColor;
    }
}
