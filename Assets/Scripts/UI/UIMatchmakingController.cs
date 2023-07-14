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

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnNetworkEventReceived;
        OnNetworkEventReceived(null);
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnNetworkEventReceived;
    }

    private void OnNetworkEventReceived(EventData obj)
    {
        Room currentRoom = PhotonNetwork.CurrentRoom;
        playerCountText.text = $"{currentRoom.PlayerCount}/{currentRoom.MaxPlayers}";

        DeleteObjectChildren(playerContainer);
        foreach (var currentPlayer in currentRoom.Players)
        {
            var playerInfoItem = Instantiate(playerInfoItemPrefab, playerContainer);
            //playerInfoItem.SetInfo(null, null, currentPlayer.Value.NickName);
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
