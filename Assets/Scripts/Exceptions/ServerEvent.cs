using Photon.Realtime;
using UnityEngine;

public class ServerEvent : MonoBehaviour
{
    public static ServerEvent Instance;

    public delegate void ServerEventHandler(byte code, object obj);
    public event ServerEventHandler OnEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RaiseEvent(byte code, object obj)
    {
        OnEvent?.Invoke(code, obj);
    }
}