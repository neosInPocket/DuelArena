using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsWindow : MonoBehaviour
{
    [SerializeField] Animator windowAnimator;
    [SerializeField] TMP_InputField nickNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] Button confirmButton;
    [SerializeField] Button closeButton; 

    [SerializeField] PlayerManager playerManager;

    private void Start()
    {
        CloseWindow();
        confirmButton.onClick.AddListener(OnConfirmButtonClick);
        closeButton.onClick.AddListener(HideWindow);
    }

    private void OnConfirmButtonClick()
    {
        try
        {
            playerManager.SaveNewPlayer(nickNameInputField.text);
        }
        catch (ArgumentException ex)
        {
            errorText.text = ex.Message;
            return;
        }

        HideWindow();
    }

    public void HideWindow()
    {
        windowAnimator.SetTrigger("Hide");
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    public void ShowWindow()
    {
        gameObject.SetActive(true);
        errorText.text = string.Empty;
        nickNameInputField.text = string.Empty;
    }
}
