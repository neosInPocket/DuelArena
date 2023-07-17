using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementControl : PlayerTouchControl
{
    private PlayerMovement playerMovement;

    protected override void Execute()
    {
        playerMovement.MovePlayer(movementAmount);
    }

    protected override void Initialize()
    {
        var joysticks = GetComponentsInChildren<FloatingJoystick>();
        joystick = joysticks.FirstOrDefault(x => !x.IsRightScreen);
        joystick.gameObject.SetActive(false);

        playerMovement = GetComponent<PlayerMovement>();
    }
}
