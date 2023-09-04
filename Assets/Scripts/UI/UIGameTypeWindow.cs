using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameTypeWindow : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button pvpButton;
    [SerializeField] private Button pwfButton;
    [SerializeField] private Button aiButton;
    [SerializeField] private MatchmakingController matchmakingController;

    private void Start()
    {
        pvpButton.onClick.AddListener(PVPMatch);
        pwfButton.onClick.AddListener(PWFMatch);
        pvpButton.onClick.AddListener(AIMatch);
    }

    private void PVPMatch()
    {
        matchmakingController.MatchPVP();
    }

    private void PWFMatch()
    {
        matchmakingController.MatchPWF();
    }

    private void AIMatch()
    {
        matchmakingController.MatchAI();
    }
}
