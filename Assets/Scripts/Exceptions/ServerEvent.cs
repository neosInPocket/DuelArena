using UnityEngine;

public class ServerEvent : MonoBehaviour
{
    public static ServerEvent Instance;

    public delegate void ServerEventHandler(string errorMessage);
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

    public void RaiseEvent(string errorMessage)
    {
        OnEvent?.Invoke(errorMessage);
    }
}