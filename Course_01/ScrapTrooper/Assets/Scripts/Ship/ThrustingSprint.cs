using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustingSprint : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMoveScript;
    [SerializeField]
    float speedMultiplier = 10f;
    float oldspeed;
    // Start is called before the first frame update
    void Awake()
    {
        playerMoveScript = GetComponent<PlayerMovement>();
        oldspeed = playerMoveScript.thrustSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           
            playerMoveScript.thrustSpeed = speedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerMoveScript.thrustSpeed = oldspeed;
        }
    }
}
