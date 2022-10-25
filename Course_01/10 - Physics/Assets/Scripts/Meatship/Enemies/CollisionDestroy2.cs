using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy2 : MonoBehaviour
{
    [SerializeField]
    private AudioClip gameOverSound;
    public Meatship playerShip;
    private void Start()
    {
      
    }

    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerShip.playerHp -= 1 * Time.deltaTime;
            //AudioSource.PlayClipAtPoint(gameOverSound, new Vector3(0, 0, 0));
            //Destroy(collision.gameObject);
            //Debug.Log ("Game Over");
            if (playerShip.playerHp == 1)
            {
                AudioSource.PlayClipAtPoint(gameOverSound, new Vector3(0, 0, 0));
                Destroy(collision.gameObject);
                Debug.Log("Game Over");
            }
        }
    }
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))       
    //    {
    //        playerShip.playerHp -= 1;
    //        //AudioSource.PlayClipAtPoint(gameOverSound, new Vector3(0, 0, 0));
    //        //Destroy(collision.gameObject);
    //        //Debug.Log ("Game Over");
    //        if (playerShip.playerHp == 1)
    //        {
    //            AudioSource.PlayClipAtPoint(gameOverSound, new Vector3(0, 0, 0));
    //            Destroy(collision.gameObject);
    //            Debug.Log("Game Over");
    //        }
    //    }
    //}
}
