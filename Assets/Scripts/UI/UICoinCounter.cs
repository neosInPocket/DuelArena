using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WebSocketSharp;
using EventData = ExitGames.Client.Photon.EventData;

public class UICoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text coinAmountText;

    private void Start()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnGameEvent;
    }

    private void OnDestroy()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnGameEvent;
    }

    private void OnGameEvent(EventData obj)
    {
        Player sender = obj.CustomData as Player;

        if (obj.Code != GameEventCodes.PLAYER_COIN && sender == null && PhotonNetwork.LocalPlayer != sender)
        {
            return;
        }

        coinAmountText.text = "coins: " + sender.CustomProperties["Coins"]?.ToString();
    }
}
