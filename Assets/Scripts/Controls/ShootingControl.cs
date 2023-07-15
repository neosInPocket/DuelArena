using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControl : PlayerTouchControl
{
    private PlayerShooting playerShooting;

    protected override void Execute()
    {
        float angle = Mathf.Atan2(movementAmount.y, movementAmount.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        playerShooting.FirePointTransform.parent.rotation = rotation;

        if (movementAmount != Vector2.zero)
        {
            StartCoroutine(playerShooting.Shoot());
        }
    }

    protected override void Initialize()
    {
        playerShooting = GetComponent<PlayerShooting>();
    }


}
