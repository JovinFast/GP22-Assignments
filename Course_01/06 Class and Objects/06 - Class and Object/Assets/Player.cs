using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    public Vector3 PlayerMovementSlide(float speed, Vector3 playerVector,float minimumSpeed, Vector3 movementDirectionVector)
    {
        if (speed > minimumSpeed)
        {
            playerVector += speed * Time.deltaTime * movementDirectionVector;
            return playerVector;
        }
        else
        {
            return playerVector;
        }
    }
    public Vector3 PlayerMovement( Vector3 positionVector, float speed)
    {
        Vector3 inputVector;
        //Take input and normalize it
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //add our new input to our x and y position, acceleration circle
        positionVector += new Vector3(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime);

        return positionVector;
    }
    public Vector3 MovementDirection(Vector3 directionVector)
    {
        directionVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return directionVector;
    }
    public float PlayerSlowDown(float speed,float minimumSpeed, float decelerationRate, Vector3 playerVector, float teleportDistance)
    {
        float teleportDistanceMinus = teleportDistance * -1;
        //if speed2 is bigger than acceleration
        if (speed >= minimumSpeed)
        {
            //Remove speed depending on set deceleration
            speed -= speed * decelerationRate * Time.deltaTime;
            return speed;
            //Keeps going in the direction
           
        }

        if (speed > teleportDistance && teleportDistanceMinus < speed)
        {
            speed = minimumSpeed;
            return speed;
        }

        else 
            {
            return speed;
            }
           
    }
    public Vector3 Wrap (Vector3 wrapVector, float radius)
    {
        if (wrapVector.y < 0 + radius)
        {
            wrapVector.y = 0 + radius;
            return wrapVector;
        }
         
        if (wrapVector.y > Height - radius) 
        {
            wrapVector.y = Height - radius;
            return wrapVector;
        }
        if (wrapVector.x <= 0)
        {
            wrapVector.x = Width;
            return wrapVector;
        }

        if (wrapVector.x > Width)
        {
            wrapVector.x = 0;
            return wrapVector;
        }
        else
        {
            return wrapVector;
        }
    }

    public Vector3 PlayerSpawnpoint(Vector3 spawnpoint)
    {
        spawnpoint.x = Width / 2;
        spawnpoint.y =  3;
        return spawnpoint;
    }

    public float Radius(float diameter)
    {
        float radius = diameter / 2;
        return radius;
    }
    public float Acceleration (float speed, float accelerationSpeed)
    {
       speed += accelerationSpeed * Time.deltaTime;
        return speed;
    }

    
 
}
