using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MatchBuilder : MonoBehaviour
{
	private MatchData _matchData;
	
	[Inject]
	private void Construct(MatchData matchData)
	{
		_matchData = matchData;
	}
}
