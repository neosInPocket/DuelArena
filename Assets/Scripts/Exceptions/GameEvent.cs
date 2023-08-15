using Photon.Realtime;
using UnityEngine;

public static class GameEvent
{
    public delegate void ServerEventHandler(byte code, object obj);
    public static event ServerEventHandler OnEvent;

    public static void RaiseEvent(byte code, object obj)
    {
        OnEvent?.Invoke(code, obj);
    }
}