using TMPro;
using UnityEngine;

public class UITextPopup : Executable
{
    [SerializeField] private Animator popupAnimator;
    [SerializeField] private TMP_Text messageText;

    public override void Execute(byte code, object obj)
    {
        messageText.text = obj.ToString();
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
