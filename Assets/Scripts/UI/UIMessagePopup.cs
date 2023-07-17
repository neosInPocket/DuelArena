using Mono.Cecil;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WebSocketSharp;

public abstract class UIMessagePopup : MonoBehaviour
{
    [SerializeField] private Animator popupAnimator;
    [SerializeField] protected TMP_Text messageText;
    [SerializeField] private PhotonView photonView;

    public string WindowCaption
    {
        get => messageText.text;
        set
        {
            messageText.text = value;
            gameObject.SetActive(true);
        }
    }

    void Start()
    {
        ServerEvent.Instance.OnEvent += OnEventHandler;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ServerEvent.Instance.OnEvent -= OnEventHandler;
    }

    protected abstract string Execute(byte code, object obj);

    private void OnEventHandler(byte code, object obj)
    {
        string message = Execute(code, obj);
        if (string.IsNullOrEmpty(message))
        {
            return;
        }

        messageText.text = Execute(code, obj);
        gameObject.SetActive(true);
    }

    public void HidePopupWindow()
    {
        popupAnimator.SetTrigger("Hide");
    }

    public void ClosePopupWindow()
    {
        gameObject.SetActive(false);
    }
}
