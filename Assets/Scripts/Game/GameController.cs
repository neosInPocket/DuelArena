using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using EventData = ExitGames.Client.Photon.EventData;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform spawnPointLeft;
    [SerializeField] private Transform spawnPointRight;
    [SerializeField] private int coinGenerateTimeout;
    [SerializeField] private Tilemap grassTileMap;

    private bool isCoinBeingGenerated;
    private PhotonView photonView;

    private GameObject playerInstance;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        PhotonNetwork.NetworkingClient.EventReceived += OnEventRecieved;


        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            SetPlayerSpawnPoint(spawnPointLeft);
        }
        else
        {
            SetPlayerSpawnPoint(spawnPointRight);
        }

        PhotonNetwork.LocalPlayer.CustomProperties["Coins"] = 0;
    }

    private void OnEventRecieved(EventData obj)
    {
        if (obj.Code == GameEventCodes.PLAYER_DEATH)
        {
            Player player = (Player)obj.CustomData;
            if (player == null)
            {
                return;
            }

            Player winPlayer = PhotonNetwork.LocalPlayer;
            foreach (Player roomPlayer in PhotonNetwork.CurrentRoom.Players.Values)
            {
                if (roomPlayer == player)
                {
                    continue;
                }

                winPlayer = roomPlayer;
            }

            string message = $"{winPlayer.NickName} win! \n his coins: {(int)winPlayer.CustomProperties["Coins"]}";
            photonView.RPC("ShowGameResultWindow", RpcTarget.AllBuffered, message);
        }
    }

    [PunRPC]
    public void ShowGameResultWindow(string message)
    {
    }

    private void FixedUpdate()
    {
        if (isCoinBeingGenerated || !PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            return;
        }

        StartCoroutine(GenerateCoin());
    }

    private IEnumerator GenerateCoin()
    {
        isCoinBeingGenerated = true;
        Vector3Int cellPosition = GetRandomTilemapCellPosition();

        
        PhotonNetwork.Instantiate("Coin", grassTileMap.CellToWorld(cellPosition), Quaternion.identity);
        yield return new WaitForSeconds(coinGenerateTimeout);
        isCoinBeingGenerated = false;
    }

    private Vector3Int GetRandomTilemapCellPosition()
    {
        BoundsInt bounds = grassTileMap.cellBounds;
        Vector3Int cellPosition = Vector3Int.zero;

        do
        {
            cellPosition = new Vector3Int(
                Random.Range(bounds.xMin, bounds.xMax),
                Random.Range(bounds.yMin, bounds.yMax),
                bounds.zMin
            );
        } while (grassTileMap.GetTile(cellPosition) == null);

        return cellPosition;
    }

    private void SetPlayerSpawnPoint(Transform spawnPoint)
    {
        playerInstance = PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);
        photonView.RPC("SetPlayerData", RpcTarget.AllBuffered);

        PhotonNetwork.LocalPlayer.CustomProperties["SpawnPoint"] = spawnPoint.position;
    }

    [PunRPC]
    private void SetPlayerData()
    {
        playerInstance.GetComponent<SpriteRenderer>().color = UserDataController.GetPlayerColor(PhotonNetwork.LocalPlayer);
        playerInstance.GetComponentInChildren<TMP_Text>().text = PhotonNetwork.LocalPlayer.NickName;
    }

    public void LeaveCurrentRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }
}
