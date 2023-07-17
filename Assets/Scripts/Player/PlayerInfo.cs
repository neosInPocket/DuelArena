using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    public PhotonView PhotonView => photonView;

    public float Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    public int Coins
    {
        get => coins;
        set => coins = value;
    }

    public event Action<float> OnPlayerHit;

    private float health = 100;
    private int coins = 0;

    public void TakeDamage(float damageAmount)
    {
        if (!photonView.IsMine)
        {
            return;
        }
        
        if (Health - damageAmount <= 0)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
            raiseEventOptions.Receivers = ReceiverGroup.MasterClient;
            PhotonNetwork.RaiseEvent(
                ServerEventCodes.PLAYER_DEATH,
                PhotonNetwork.LocalPlayer,
                raiseEventOptions,
                SendOptions.SendReliable
                );
        }

        Health -= damageAmount;
        OnPlayerHit?.Invoke(Health);
    }

    public void AddCoin()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        
        Coins++;
        PhotonNetwork.LocalPlayer.CustomProperties["Coins"] = Coins;

        RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
        raiseEventOptions.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(
                ServerEventCodes.PLAYER_COIN,
                PhotonNetwork.LocalPlayer,
                raiseEventOptions,
                SendOptions.SendReliable
            );
    }
}
