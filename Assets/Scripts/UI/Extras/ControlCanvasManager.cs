using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvasManager : MonoBehaviour
{
    private PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }
}
