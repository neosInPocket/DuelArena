using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLoader : ObserverContainer
{
    public override void OnNext(EventArgs args)
    {
        if (args is not MatchmakingEventArgs mmArgs) return;


    }
}
