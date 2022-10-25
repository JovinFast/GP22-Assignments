using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    public bool grounded;
    [SerializeField]
    private PlayerController playerScript;
    public bool isTouching;
    Vector3 playerPosition;
    public GameObject player;
    private void Update()
    {

         if (Input.GetKeyDown(KeyCode.F) && grounded && isTouching)
            {
                this.transform.position += new Vector3(0, 3, 0);
            }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouching = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouching = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        isTouching = true;
    }








}
