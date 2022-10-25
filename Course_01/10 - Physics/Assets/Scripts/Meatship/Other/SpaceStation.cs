using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    [SerializeField]
    private Meatship playerShip;
    public int hpMultiplier = 3;
    
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (playerShip.playerHp < 100)
                {
                playerShip.docked = true;
                playerShip.playerHp += hpMultiplier * Time.deltaTime;                
                }
            if (playerShip.playerHp >= 100)
            {
                playerShip.docked = false;
            }

        }
        }
    
}
