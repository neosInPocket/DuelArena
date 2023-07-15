using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public string NickName { get; set; }
    public Color Color { get; set; }
    public Player Player { get; set; }

    public PlayerInfo(string nickName, Color color, Player player)
    {
        NickName = nickName;
        Color = color;
        Player = player;
    }
}
