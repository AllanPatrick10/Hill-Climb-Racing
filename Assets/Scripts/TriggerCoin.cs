using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoin : MonoBehaviour
{
    public GameManager player;
    public int coinValue;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.totalCoin += coinValue;
        Destroy(gameObject);
    }
}
