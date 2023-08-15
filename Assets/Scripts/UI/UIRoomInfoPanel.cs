using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class UIRoomInfoItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomNameText;
    [SerializeField] private TMP_Text playerCountText;
    [SerializeField] private TMP_Text roomCreatorText;

    private RoomInfo roomInfo;

    public void Initialize(RoomInfo roomInfo, string roomCreator)
    {
        this.roomInfo = roomInfo;
        roomNameText.text = roomInfo.Name;
        roomCreatorText.text = roomCreator;
        Refresh();
    }

    public void Refresh()
    {
        playerCountText.text = $"{roomInfo.PlayerCount}/{roomInfo.MaxPlayers}";
    }
}
