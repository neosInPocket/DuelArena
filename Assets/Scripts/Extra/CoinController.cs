using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo playerInfo = collision.gameObject.GetComponent<PlayerInfo>();
        if (playerInfo != null)
        {
            playerInfo.AddCoin();
            Destroy(gameObject);
        }
    }
}
