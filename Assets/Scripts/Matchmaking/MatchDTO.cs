using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchDTO", menuName = "Data/MatchDTO")]
public class MatchDTO : ScriptableObject
{
    private MatchData _data;

    public MatchData Data
    {
        get => _data;
        set => _data = value;
    }
}
