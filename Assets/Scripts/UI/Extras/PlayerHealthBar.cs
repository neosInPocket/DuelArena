using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private PhotonView photonView;
    private PlayerInfo playerInfo;
    private Image fillImage;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerInfo = GetComponentInParent<PlayerInfo>();
        fillImage = GetComponent<Image>();
        playerInfo.OnPlayerHit += RefreshViaRPC;
    }

    private void RefreshViaRPC(float data)
    {
        photonView.RPC("RefreshHealthBar", RpcTarget.AllViaServer, data);
    }

    [PunRPC]
    private void RefreshHealthBar(float data)
    {
        fillImage.fillAmount = data / 100;
    }
}
