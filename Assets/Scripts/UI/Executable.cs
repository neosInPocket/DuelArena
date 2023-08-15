using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Executable : MonoBehaviour
{
    public abstract void Execute(byte code, object obj);
}
