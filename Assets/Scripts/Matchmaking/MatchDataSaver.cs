using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public static class MatchDataSaver
{
    private const string SavefilePath = "Data/MatchDTO";

    public static void SaveMatchData(MatchData data)
    {
        var saveFile = Resources.Load<MatchDTO>(SavefilePath);

        if (saveFile == null)
        {
            throw new NullReferenceException();
        }

        saveFile.Data = data;
    }
}
