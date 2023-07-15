using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    public event Action<Player> OnPlayerDeath;
    public event Action<float> OnPlayerHit;
    private float health = 100;

    public void TakeDamage(float damageAmount)
    {
        if (Health - damageAmount <= 0)
        {
            OnPlayerDeath?.Invoke(PhotonNetwork.LocalPlayer);
            return;
        }

        Health -= damageAmount;
        OnPlayerHit?.Invoke(Health);
    }
}
