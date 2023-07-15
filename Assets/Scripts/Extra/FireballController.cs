using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerInfo>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
