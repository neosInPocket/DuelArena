using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataControl : MonoBehaviour, IPunObservable
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TMP_Text nickNameText;
    [SerializeField] private TMP_Text coinsAmountText;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Color color = spriteRenderer.color;
            stream.SendNext(PlayerManager.GetVectorFromColor(color));

            stream.SendNext(PhotonNetwork.LocalPlayer.NickName);
        }
        else if (stream.IsReading)
        {
            Vector3 vectorColor = (Vector3)stream.ReceiveNext();
            spriteRenderer.color = PlayerManager.GetColorFromVector(vectorColor);

            nickNameText.text = stream.ReceiveNext().ToString();
        }
    }
}
