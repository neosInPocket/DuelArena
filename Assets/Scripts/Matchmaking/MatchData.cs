using System;
using UnityEngine;

[Serializable]
public class MatchData
{
    private Type _matchType;

    public Type MatchType
    {
        get => _matchType;
        set => _matchType = value;
    }

    public MatchData(IMatchBehaviour match)
    {
        _matchType = match.GetType();
    }
}
