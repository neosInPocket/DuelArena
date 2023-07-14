using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISettingsWindow : MonoBehaviour
{
    [SerializeField] Animator windowAnimator;
    [SerializeField] TMP_Text errorText;

    private void Start()
    {
        CloseWindow();
    }

    public void HideWindow()
    {
        windowAnimator.SetTrigger("Confirm");
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    public void ShowWindow()
    {
        gameObject.SetActive(true);
        errorText.text = string.Empty;
    }
}
