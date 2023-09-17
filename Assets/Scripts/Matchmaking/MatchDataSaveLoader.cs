using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using Unity.VisualScripting.Dependencies.NCalc;

public static class MatchDataSaveLoader
{
    private const string SavefilePath = "Data/MatchDTO";

    public static void SaveMatchData(MatchData data)
    {
        var saveFile = Resources.Load<MatchDTO>(SavefilePath);

        if (saveFile == null) throw new NullReferenceException();

        saveFile.Data = data;
    }

    public static MatchData LoadMatchData()
    {
        var saveFile = Resources.Load<MatchDTO>(SavefilePath);

        if (saveFile.Data == null) throw new NullReferenceException();

        return saveFile.Data;
    }
}
