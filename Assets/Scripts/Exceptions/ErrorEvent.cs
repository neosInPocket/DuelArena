using UnityEngine;

public class ErrorEvent : MonoBehaviour
{
    public static ErrorEvent Instance;

    public delegate void ErrorEventHandler(string errorMessage);
    public event ErrorEventHandler OnError;

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

    public void RaiseError(string errorMessage)
    {
        OnError?.Invoke(errorMessage);
    }
}