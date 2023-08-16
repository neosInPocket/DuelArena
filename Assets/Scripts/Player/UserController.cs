using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class UserController : MonoBehaviour
{   
    public void SaveNewPlayer(string nickName)
    {
        if (nickName.IsNullOrEmpty())
        {
            throw new ArgumentException("Nickname must contain at least 1 symbol");
        }

        if (nickName.Length > 10)
        {
            throw new ArgumentException("Nickname must contain less than 10 symbols");
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

    public static Color GetPlayerColor(Player player)
    {
        var vector = (Vector3)player.CustomProperties["Color"];
        var color = new Color(vector.x, vector.y, vector.z);
        return color;
    }

    public static Color GetColorFromVector(Vector3 vectorColor)
    {
        Color color = new Color(vectorColor.x, vectorColor.y, vectorColor.z);
        return color;
    }

    public static Vector3 GetVectorFromColor(Color color)
    {
        Vector3 colorVector = new Vector3(color.r, color.g, color.b);
        return colorVector;
    }
}
