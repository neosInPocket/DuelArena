using Photon.Pun;
using Photon.Realtime;
using System;

public class PVPMatchBehaviour : IMatchBehaviour, IRoomCallback
{
	public Action MatchMade { get; set; }
	public Action Disposed { get ; set ; }

	public void Match()
	{
		PhotonNetwork.JoinRandomOrCreateRoom();
	}

	public void OnRoomCallback(object obj)
	{
		if (!PhotonNetwork.IsMasterClient) return;
		
		if (obj is Player player) MatchMade?.Invoke();
		
		MatchMade?.Invoke();
	}

	public void Dispose()
	{
		PhotonNetwork.LeaveRoom();
		Disposed?.Invoke();
	}
}
