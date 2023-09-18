using Photon.Pun;

public static class MatchLoader
{
    public static void LoadMatch(IMatchBehaviour match)
    {
        MatchDataSaveLoader.Save(new MatchData(match));
        PhotonNetwork.LoadLevel(1);
    }
}
