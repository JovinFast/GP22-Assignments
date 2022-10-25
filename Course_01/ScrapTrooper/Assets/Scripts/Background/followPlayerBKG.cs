using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerBKG : MonoBehaviour
{
    public GameObject playerShip;
    public float moveSpeed = 0.2f;
    private PlayerMovement playerScript;
    private bool isMoving;


    private void Start()
    {
        
        playerShip = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
       isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

       if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerShip.transform.position, moveSpeed * Time.deltaTime);
        }
       
    }

}
