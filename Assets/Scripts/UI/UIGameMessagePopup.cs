using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameMessagePopup : UIMessagePopup
{
    protected override string Execute(byte code, object obj)
    {
        if (code != ServerEventCodes.PLAYER_WIN)
        {
            return null;
        }

        string message = obj.ToString();
        return message;
    }
}
