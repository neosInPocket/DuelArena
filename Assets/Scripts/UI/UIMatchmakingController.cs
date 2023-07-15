using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMatchmakingController : MonoBehaviour
{
    [SerializeField] TMP_Text playerCountText;
    [SerializeField] Transform playerContainer;
    [SerializeField] UIPlayerInfoPanel playerInfoItemPrefab;
    [SerializeField] PhotonView playerListPhotonView;

    private Room currentRoom;

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnNetworkEventReceived;
        SyncRoomInfo();
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnNetworkEventReceived;
    }

    private void OnNetworkEventReceived(EventData obj)
    {
        PlayerInfo playerInfo = obj.CustomData as PlayerInfo;
        if (playerInfo == null)
        {
            return;
        }

        playerListPhotonView.RPC("SyncRoomInfo", RpcTarget.AllBuffered, playerInfo);
    }

    [PunRPC]
    private void SyncRoomInfo()
    {
        currentRoom = PhotonNetwork.CurrentRoom;

        playerCountText.text = $"{currentRoom.PlayerCount}/{currentRoom.MaxPlayers}";
        DeleteObjectChildren(playerContainer);
        foreach (var player in currentRoom.Players)
        {
            var playerInfoItem = Instantiate(playerInfoItemPrefab, playerContainer);
            playerInfoItem.SetInfo(Global.GetPlayerInfo(player.Value));
        }
    }

    private void DeleteObjectChildren(Transform obj)
    {
        foreach (Transform child in obj)
        {
            Destroy(child.gameObject);
        }
    }
}
