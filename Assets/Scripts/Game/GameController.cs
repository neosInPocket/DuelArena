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
        foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            var currentSpawnPoint = (Vector3)player.CustomProperties["SpawnPoint"];
            if (currentSpawnPoint == spawnPointLeft.position)
            {
                SetPlayerSpawnPoint(spawnPointRight);
                return;
            }

            if (currentSpawnPoint == spawnPointRight.position)
            {
                SetPlayerSpawnPoint(spawnPointLeft);
                return;
            }

            SetPlayerSpawnPoint(spawnPointRight);
        }
        
    }

    private void SetPlayerSpawnPoint(Transform spawnPoint)
    {
        PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);
        PhotonNetwork.LocalPlayer.CustomProperties["SpawnPoint"] = spawnPoint.position;
    }
}
