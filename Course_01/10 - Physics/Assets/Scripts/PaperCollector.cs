using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollector : MonoBehaviour
{
    private PlayerController playerScript;
    private void Awake()
    {
        playerScript = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            playerScript.coinAmount += 1;
            Debug.Log(playerScript.coinAmount);

        }
    }

}
