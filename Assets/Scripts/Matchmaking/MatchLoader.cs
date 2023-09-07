using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class MatchLoader
{
    public static void LoadMatch(IMatchBehaviour match)
    {
        MatchDataSaver.SaveMatchData(new MatchData(match));
        PhotonNetwork.LoadLevel(1);
    }
}
