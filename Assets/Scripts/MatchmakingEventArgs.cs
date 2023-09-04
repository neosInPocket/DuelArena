using System;

public class MatchmakingEventArgs : EventArgs
{
    public Type MatchmakingType { get; set; }
    public object Sender { get; set; }
}
