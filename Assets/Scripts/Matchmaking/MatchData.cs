using System;
using UnityEngine;

[Serializable]
public class MatchData
{
    private Type _matchType;

    public Type MatchType => _matchType;

    public MatchData(IMatchBehaviour match)
    {
        _matchType = match.GetType();
    }
}
