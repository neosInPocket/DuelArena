using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

public class RoomsCallbackController : MonoBehaviourPunCallbacks
{
    public List<IRoomCallback> Observers { get; set; } = new List<IRoomCallback>();

    public void Subscribe(IRoomCallback observer)
    {
        Observers.Add(observer);
        print("Subscribed");
    }

    private void Notify(object obj)
    {
        foreach (var observer in Observers) observer.OnRoomCallback(obj);
    }

    public override void OnJoinedRoom()
    {
        print("Room controller room callback");
        Notify(null);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("New player joined the room");
        Notify(newPlayer);
    }
}
