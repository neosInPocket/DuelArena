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
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        Player player = (Player)obj.CustomData;

        if (player == null)
        {
            return;
        }

        Room currentRoom = PhotonNetwork.CurrentRoom;
        playerCountText.text = $"{currentRoom.MaxPlayers}/{currentRoom.PlayerCount}";

        if (obj.Code == ServerEventCodes.PLAYER_ENTERED_ROOM || obj.Code == ServerEventCodes.PLAYER_LEFT_ROOM)
        {
            DeleteObjectChildren(playerContainer);
            foreach (var currentPlayer in currentRoom.Players)
            {
                var playerInfoItem = Instantiate(playerInfoItemPrefab, playerContainer);
                playerInfoItem.SetInfo(null, null, player.NickName);
            }
            return;
        }

        if (obj.Code == ServerEventCodes.PLAYER_LEFT_ROOM)
        {
            
            return;
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
