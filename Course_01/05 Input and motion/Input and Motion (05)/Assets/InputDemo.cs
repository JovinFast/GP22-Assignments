using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDemo : ProcessingLite.GP21
{
    float diameter = 2;
    public float speed2 = 3f;
    [Range (0,30)] public float speed = 1f;
    public float acceleration = 3f;
    public float speedLimit = 10;
    public float deceleration = -0.5f;
    public float gravityForce = 3f;
    public float speedMin = 3f;


    private Vector3 originalCircle;
    private Vector3 accelerationCircle;
    private Vector3 movementDirectionVector;
    private Vector3 moveOriginal;
    private Vector3 moveAccCircle;

    //Teleportation when close to goal
    float accelerationCloseUp; //How far + 
    float accelerationCloseDown;//How far -
    public float teleportDistance = 0.1f;

    bool gravity = false;

    void Start()
    {
 
        //Starting positions for circles
        originalCircle.x = Width / 2;
        originalCircle.y = Height / 2;
        accelerationCircle.x = originalCircle.x;
        accelerationCircle.y = originalCircle.y + 2;
        
    }

    void Update()
    {
        Background(50, 166, 240);

        float radius = diameter / 2;

        accelerationCloseDown = speedMin - teleportDistance; 
        accelerationCloseUp = speedMin + teleportDistance;
        speed2 += acceleration * Time.deltaTime;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) //Vid movement input gör detta
        {
            //Take input and normalize it
            moveOriginal = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            //add our new input to our x and y position, original circle
            originalCircle += new Vector3(moveOriginal.x * speed * Time.deltaTime, moveOriginal.y * speed * Time.deltaTime);

            //Take input and normalize it
            moveAccCircle = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            //add our new input to our x and y position, acceleration circle
            accelerationCircle += new Vector3(moveAccCircle.x * speed2 * Time.deltaTime, moveAccCircle.y * speed2 * Time.deltaTime);

            movementDirectionVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //Varför klipper den till x eller y axel vid GetAxisRaw??????????
        }


        //Wrap
        //Original Circle
        if (originalCircle.y < 0 + radius) originalCircle.y = 0 + radius;

        if (originalCircle.y > Height - radius) originalCircle.y = Height - radius;

        if (originalCircle.x <0) originalCircle.x = Width;

        if (originalCircle.x > Width) originalCircle.x = 0;

        //Acceleration Circle

        if (accelerationCircle.y  < 0 + radius) accelerationCircle.y = 0 + radius;

        if (accelerationCircle.y > Height - radius) accelerationCircle.y = Height - radius;

        if (accelerationCircle.x <=0) accelerationCircle.x = Width;

        if (accelerationCircle.x > Width) accelerationCircle.x = 0;
 


        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")) // With no input from movement do this
        {
            //if speed2 is bigger than acceleration
            if (speed2 >= speedMin)
            {
             //Remove speed depending on set deceleration
             speed2 -= speed2 * deceleration * Time.deltaTime;

                //Keeps going in the direction
                if (speed2 > speedMin)
                {
                    accelerationCircle += speed2 * Time.deltaTime * movementDirectionVector;
                }
            }
            //If speed2 is bigger or lower then set value in "teleportDistance" set it to acceleration.
            if (speed2 > accelerationCloseDown && speed2 < accelerationCloseUp)
            {
                speed2 = speedMin ;
            }
        }


        //Speed limit
        if (speed2 >= speedLimit)
        {
            speed2 = speedLimit;
        }
        
        Circle(originalCircle.x, originalCircle.y, diameter);//Original Circle 
        //Original Circle kopior
        Circle(originalCircle.x - Width, originalCircle.y, diameter);
        Circle(originalCircle.x + Width, originalCircle.y, diameter);
              
        
        Circle(accelerationCircle.x, accelerationCircle.y, diameter);//Cirkle with acceleration
        Circle(accelerationCircle.x + Width, accelerationCircle.y, diameter);
        Circle(accelerationCircle.x - Width, accelerationCircle.y, diameter);

        //Pressing g on the keyboard should toggle gravity on or off.
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (gravity == false)
            {
                gravity = true;
            }
            else 
            {
                gravity = false;
            }
        }
        //With gravity on the circle / character should fall down and bounce on the bottom of the screen.
        //if (gravity)
        //{
            
        //    originalcircle.y  -= gravityforce * time.deltatime;
        //    if (originalcircle.y + radius == 0)
        //    {

        //    }
        //}


    }
}
