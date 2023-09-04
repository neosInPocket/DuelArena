using Photon.Pun;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MatchmakingController : MonoBehaviour
{
    [SerializeField] private List<ObserverContainer> _observers;
    [SerializeField] private RoomsCallbackController _roomsController;
    private IMatchBehaviour _currentMatch;
    public IMatchBehaviour CurrentMatch => _currentMatch;

    private void Notify(MatchmakingEventArgs args)
    {
        foreach (var observer in _observers) observer.OnNext(args);
    }

    private void Match(IMatchBehaviour match)
    {
        _currentMatch = match;
        match.Match();
        Notify(new MatchmakingEventArgs() { MatchmakingType = match.GetType(), Sender = this });
    }

    public void Dispose()
    {
        CurrentMatch?.Dispose();
    }

    public void MatchPVP()
    {
        var pvpMatch = new PVPMatchBehaviour();
        _roomsController.Subscribe(pvpMatch);
        Match(pvpMatch);
    }

    public void MatchPWF()
    {
        throw new NotImplementedException();
    }

    public void MatchAI()
    {
        throw new NotImplementedException();
    }
}
