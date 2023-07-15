using System.Collections;
using System.Collections.Generic;
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
        playerMovement = GetComponent<PlayerMovement>();
    }
}
