using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIConnectingStatusPanel : MonoBehaviour
{
    [SerializeField] Animator connectingStatusAnimator;
    [SerializeField] TMP_Dropdown serversDropDown;
    [SerializeField] TMP_Text connectionStatusCaption;
    [SerializeField] ConnectionManager connectionManager; 

    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        string serverName = serversDropDown.captionText.text;
        connectionStatusCaption.text = "Connecting to " + serverName + " ...";
        connectingStatusAnimator.SetTrigger("Connecting");
        
        bool connectionResult = connectionManager.ConnectPlayerToRegion(serverName);
        connectingStatusAnimator.SetBool("IsConnected", connectionResult);

        if (connectionResult)
        {
            connectionStatusCaption.text = "Connected!";
        }
        else
        {
            connectionStatusCaption.text = "Error connecting to " + serverName;
        }
    }
}
