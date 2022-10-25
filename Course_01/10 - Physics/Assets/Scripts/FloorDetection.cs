using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    
    private PlayerController playerScript;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GetComponentInParent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.layer == 6)
        {
            playerScript.grounded = true;
        }

            
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerScript.grounded = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(playerScript.grounded);
    }

}
