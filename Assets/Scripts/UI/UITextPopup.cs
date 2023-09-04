using TMPro;
using UnityEngine;

public class UITextPopup : MonoBehaviour
{
    [SerializeField] private Animator popupAnimator;
    [SerializeField] private TMP_Text messageText;

    public void Execute(byte code, object obj)
    {
        messageText.text = obj.ToString();
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
