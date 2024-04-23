using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMap : MonoBehaviour
{
    public Player player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.gasoline = 1; // gasolina no mapa que o player recebe
        Destroy(gameObject);
    }
}
