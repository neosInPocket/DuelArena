using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text nickname;
    [SerializeField] Image colorIcon;

    private string NickName
    {
        get => nickname.text;
        set => nickname.text = value;
    }

    private Color ColorIcon
    {
        get => colorIcon.color;
        set => colorIcon.color = value;
    }

    public void SetInfo(PlayerInfo playerInfo)
    {
        NickName = playerInfo.NickName;
        ColorIcon = playerInfo.Color;
    }
}
