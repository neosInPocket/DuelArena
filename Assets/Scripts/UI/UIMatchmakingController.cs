using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class UIMatchmakingController : MonoBehaviour
{
    [SerializeField] TMP_Text playerCountText;
    [SerializeField] Button startGameButton;
    [SerializeField] Animator loadingImageAnimator;
    [SerializeField] Transform playerContainer;
    [SerializeField] UIPlayerInfoPanel playerInfoItemPrefab;
    [SerializeField] PhotonView playerListPhotonView;

    private Room currentRoom;

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnNetworkEventReceived;
        SyncRoomInfo();

        if (!PhotonNetwork.IsMasterClient)
        {
            startGameButton.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnNetworkEventReceived;
    }

    private void OnNetworkEventReceived(EventData obj)
    {
        Player connectedPlayer = obj.CustomData as Player;
        if (connectedPlayer == null)
        {
            return;
        }

        playerListPhotonView.RPC("SyncRoomInfo", RpcTarget.AllBuffered);
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
            playerInfoItem.SetInfo(player.Value);
        }

        if (currentRoom.PlayerCount == currentRoom.MaxPlayers)
        {
            startGameButton.interactable = true;
            loadingImageAnimator.SetTrigger("RoomIsReady");
        }
        else
        {
            startGameButton.interactable = false;
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
