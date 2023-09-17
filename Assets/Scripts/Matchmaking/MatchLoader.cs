using Photon.Pun;

public static class MatchLoader
{
    public static void LoadMatch(IMatchBehaviour match)
    {
        MatchDataSaveLoader.SaveMatchData(new MatchData(match));
        PhotonNetwork.LoadLevel(1);
    }
}
