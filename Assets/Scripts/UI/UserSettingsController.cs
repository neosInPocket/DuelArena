using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using WebSocketSharp;

public class UserSettingsController : MonoBehaviour
{
    public void SaveUserNickName(string nickName)
    {
        if (nickName.IsNullOrEmpty())
        {
            GameEvent.RaiseEvent(GameEventCodes.NOTIFICATION, "Nickname cannot be empty");
            return;
        }

        if (nickName.Length > 10)
        {
            GameEvent.RaiseEvent(GameEventCodes.NOTIFICATION, "Nickname must contain less than 10 symbols");
            return;
        }

        if (nickName == PhotonNetwork.LocalPlayer.NickName)
        {
            return;
        }

        PhotonNetwork.LocalPlayer.NickName = nickName;
        GameEvent.RaiseEvent(GameEventCodes.NOTIFICATION, $"Saved as {nickName}!");
    }

    public void SaveUserAvatar()
    {

    }
}
