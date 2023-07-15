using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
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

        PhotonNetwork.LocalPlayer.CustomProperties["Color"] = GetRandomColor();
        PhotonNetwork.NickName = nickName;
    }

    private static Vector3 GetRandomColor()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        return new Vector3(r, g, b);
    }

    public static Color GetColorFromVector(Vector3 vector)
    {
        return new Color(vector.x, vector.y, vector.z);
    }
}
