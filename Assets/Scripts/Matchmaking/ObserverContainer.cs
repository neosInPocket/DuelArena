using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObserverContainer : MonoBehaviour, IObserver
{
    public abstract void OnNext(EventArgs args);
}