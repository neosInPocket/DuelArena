using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private List<Executable> executables;
    private void Start()
    {
        GameEvent.OnEvent += ProcessEvent;
    }

    private void OnDestroy()
    {
        GameEvent.OnEvent -= ProcessEvent;
    }

    private void ProcessEvent(byte code, object obj)
    {
        foreach (var executable in executables)
        {
            executable.Execute(code, obj);
        }
    }
}
