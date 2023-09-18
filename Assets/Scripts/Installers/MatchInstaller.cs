using System;
using UnityEngine;
using Zenject;

public class MatchInstaller : MonoInstaller
{
	[SerializeField] private MatchBuilder _matchBuilder;
	
	public override void InstallBindings()
	{
		Container.BindInstance(_matchBuilder);
		Container.Bind<MatchData>().FromFactory<MatchDataSaveLoader>().AsTransient();
	}
}