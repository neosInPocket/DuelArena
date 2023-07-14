using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public Color Color { get; set; }

    public PlayerInfo(string nickName, Color color)
    {
        NickName = nickName;
        Color = color;
    }
}
