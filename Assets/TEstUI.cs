using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEstUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void Write(string caption)
    {
        text.text += caption;
    }
}
