using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIExceptionPopup : MonoBehaviour
{
    [SerializeField] Animator popupAnimator;
    [SerializeField] TMP_Text messageText;
    void Start()
    {
        ErrorEvent.Instance.OnError += OnError;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ErrorEvent.Instance.OnError -= OnError;
    }

    private void OnError(string errorMessage)
    {
        messageText.text = errorMessage;
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
