using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static List<PlayerInfo> AllPlayers;

    public static void AddNewPlayer(PlayerInfo playerInfo)
    {
        AllPlayers.Add(playerInfo);
    }

    static Global()
    {
        AllPlayers = new List<PlayerInfo>();
    }
}
