using Photon.Realtime;
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

    private Vector3 ColorIcon
    {
        get => new Vector3(colorIcon.color.r, colorIcon.color.g, colorIcon.color.b);
        set => colorIcon.color = new Color(value.x, value.y, value.z);
    }

    public void SetInfo(Player player)
    {
        NickName = player.NickName;
        ColorIcon = (Vector3)player.CustomProperties["Color"];
    }
}
