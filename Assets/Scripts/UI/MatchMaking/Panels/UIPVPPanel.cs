using System;
using UnityEngine;

public class UIPVPPanel : ObserverContainer 
{
    public override void OnNext(EventArgs args)
    {
        if (args is not MatchmakingEventArgs mmArgs) return;
        if (mmArgs.Sender is not MatchmakingController controller) return;

        controller.CurrentMatch.MatchMade += MatchMadeHandle;
    }

    private void MatchMadeHandle()
    {
        print("Match made");
    }
}
