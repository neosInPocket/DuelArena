using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUserSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField nickNameInputField;
    [SerializeField] private UserSettingsController controller;

    private void Start()
    {
        nickNameInputField?.onDeselect.AddListener(controller.SaveUserNickName);
    }

    private void OnEnable()
    {
        nickNameInputField.text = PhotonNetwork.LocalPlayer.NickName;
    }
}
