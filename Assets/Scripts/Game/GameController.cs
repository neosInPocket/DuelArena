using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform spawnPointLeft;
    [SerializeField] private Transform spawnPointRight;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            SetPlayerSpawnPoint(spawnPointLeft);
        }
        else
        {
            SetPlayerSpawnPoint(spawnPointRight);
        }
    }

    private void SetPlayerSpawnPoint(Transform spawnPoint)
    {
        PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);
        PhotonNetwork.LocalPlayer.CustomProperties["SpawnPoint"] = spawnPoint.position;
    }
}
