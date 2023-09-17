using UnityEngine;

public class MatchEntryPoint : MonoBehaviour
{
    private void Start()
    {
        var matchMata = MatchDataSaveLoader.LoadMatchData();
        Debug.Log(matchMata.MatchType);
    }
}
