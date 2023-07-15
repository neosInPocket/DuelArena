using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rigidBody;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 movementAmount)
    {
        Vector2 scaledMovement = speed * Time.deltaTime * new Vector2(movementAmount.x, movementAmount.y);

        rigidBody.velocity = scaledMovement;
    }
}
