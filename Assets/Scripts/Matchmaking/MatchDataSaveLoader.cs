using UnityEngine;
using System;
using Zenject;

public class MatchDataSaveLoader : IFactory<MatchData>
{
    private const string SavefilePath = "Data/MatchDTO";

    public static void Save(MatchData data)
    {
        var saveFile = Resources.Load<MatchDTO>(SavefilePath);

        if (saveFile == null) throw new NullReferenceException();

        saveFile.Data = data;
    }

    public MatchData Create()
    {
        var saveFile = Resources.Load<MatchDTO>(SavefilePath);

        if (saveFile.Data == null) throw new NullReferenceException();

        return saveFile.Data;
    }
}
