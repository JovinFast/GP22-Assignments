using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public bool thrusting;
    private float turnDirection;
    
    public float thrustSpeed = 1f;
    [SerializeField]
    float turnSpeed = 1f;

    private Rigidbody2D rigidbodyThis;
    [SerializeField]
    private StatsHandler statsHandler;
    [SerializeField]
    private GameObject bulletType;

    bool shieldDown;
    public int playerHitsound = 0;

    [SerializeField]
    ShieldScript shieldScript;

    private void Awake()
    {
        //shieldScript = GetComponent<ShieldScript>();
        rigidbodyThis = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        
        //Movement
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        
        //Turning Left
        if (Input.GetKey(KeyCode.A)||  Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        //Turning Right
        else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        //No Turning
        else
        {
            turnDirection = 0f;
        }
    }
    //Fixed update, not rendering every frame, used for physics
    private void FixedUpdate()
    {
        if (thrusting)
        {
            rigidbodyThis.AddForce(this.transform.up * this.thrustSpeed);
            Debug.Log("thrustspeed: "+thrustSpeed);
        }
        if (turnDirection != 0.0f)
        {
            rigidbodyThis.AddTorque(turnDirection * this.turnSpeed);
        }
        //Dont colide with bullets
        //Physics2D.IgnoreCollision(bulletType.GetComponent<Collider2D>(), thisCollider, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shieldScript.shieldDown == true && collision.gameObject.tag == "Satelite")
        {
            
                playerHitsound++;
                statsHandler.playerHP -= 1;
                rigidbodyThis.velocity = Vector3.zero;
                rigidbodyThis.angularVelocity = 0;
                gameObject.SetActive(false);
            
        }
        
    }

}
