using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class UIExceptionPopup : UIMessagePopup
{
    protected override string Execute(byte code, object obj)
    {
        string message = obj.ToString();
        return message;
    }
}
