using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfBallOnFloor : MonoBehaviour
{
    
    private BallScript ballScript;

    // Start is called before the first frame update
    void Awake()
    {
        ballScript = GetComponentInParent<BallScript>();
    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.layer == 6)
        {
            ballScript.grounded = true;
        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {

        ballScript.grounded = false;
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(ballScript.grounded + "Ball");
    }

}
