using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Color = UnityEngine.Color;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nickNameInputField;
    [SerializeField] TMP_Text errorText;

    public void SaveNewPlayer()
    {
        string nickName = nickNameInputField.text;
        if (nickName.IsNullOrEmpty())
        {
            errorText.text = "Nickname must contain at least 1 symbol";
            return;
        }
        
        if (Global.AllPlayers.Select(x => x.NickName).Contains(nickName))
        {
            errorText.text = "This nickname is unavaliable";
            return;
        }
        PlayerInfo playerInfo = new PlayerInfo(nickNameInputField.text, GenerateUniquePlayerColor());
        Global.AddNewPlayer(playerInfo);
    }

    public static Color GenerateUniquePlayerColor()
    {
        Color rngColor = GetRandomColor();
        List<Color> existingColors = Global.AllPlayers.Select(x => x.Color).ToList();
        
        while (existingColors.Contains(rngColor))
        {
            rngColor = GetRandomColor();
        }

        return rngColor;
    }

    private static Color GetRandomColor()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        return new Color(r, g, b);
    }
}
