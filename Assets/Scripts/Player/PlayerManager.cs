using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    public void SaveNewPlayer(string nickName)
    {
        if (nickName.IsNullOrEmpty())
        {
            throw new ArgumentException("Nickname must contain at least 1 symbol");
        }
        
        if (Global.AllPlayers.Select(x => x.NickName).Contains(nickName))
        {
            throw new ArgumentException("This nickname is unavaliable"); 
        }

        PlayerInfo playerInfo = new PlayerInfo(nickName, GenerateUniquePlayerColor(), PhotonNetwork.LocalPlayer);
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
