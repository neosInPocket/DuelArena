using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfoPanel : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text nickname;
    [SerializeField] Image colorIcon;

    private Sprite Icon
    {
        get => icon.sprite;
        set => icon.sprite = value;
    }

    private string NickName
    {
        get => nickname.text;
        set => nickname.text = value;
    }

    private Sprite ColorIcon
    {
        get => colorIcon.sprite;
        set => colorIcon.sprite = value;
    }

    public void SetInfo(Sprite icon, Sprite colorIcon, string nickName)
    {
        NickName = nickName;
        Icon = icon;
        ColorIcon = colorIcon;
    }
}
