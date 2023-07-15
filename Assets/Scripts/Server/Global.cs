using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static List<PlayerInfo> AllPlayers;
    private static PhotonView photonView;

    public static void AddNewPlayer(PlayerInfo playerInfo)
    {
        PlayerInfo existingPlayer = Global.AllPlayers.Find(x => x.Player == PhotonNetwork.LocalPlayer);

        if (existingPlayer != null)
        {
            AllPlayers.Remove(existingPlayer);
        }

        AllPlayers.Add(playerInfo);
        PhotonNetwork.NickName = playerInfo.NickName;
    }

    public static PlayerInfo GetPlayerInfo(Player player)
    {
        return Global.AllPlayers.Find(x => x.Player == PhotonNetwork.LocalPlayer);
    }

    public static PlayerInfo GetCurrentPlayerInfo()
    {
        return GetPlayerInfo(PhotonNetwork.LocalPlayer);
    }

    static Global()
    {
        AllPlayers = new List<PlayerInfo>();
    }
}
