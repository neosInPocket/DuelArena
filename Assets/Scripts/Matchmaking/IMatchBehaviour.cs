using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMatchBehaviour : IDisposable
{
    public Action Disposed { get; set; }
    public Action MatchMade { get; set; }
    public void Match();
}
