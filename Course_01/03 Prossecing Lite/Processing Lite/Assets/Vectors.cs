using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectors : ProcessingLite.GP21
{
    

    [Range(0, 10)] public float diameter = 2f;
    [Range (-3,4)] public float Speed = 2;
    private Vector2 movementDirection;
    public Vector2 circlePosition;
    public Vector2 cursorPosition;
    private float speedSaver = 0f; //Sparar speedvärdet medans den pausar 
    

    // Update is called once per frame
    void Update()
    {
        float radius = diameter / 2;
        
        
    Background(180);
        
        if (Input.GetMouseButtonDown(0))
        {
            speedSaver = Speed;
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
        }
        if(Input.GetMouseButton(0))
        {           
            Speed = 0;
            cursorPosition.x = MouseX;
            cursorPosition.y = MouseY;
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);          
        }
        if (Input.GetMouseButtonUp(0))
        {            
            movementDirection =  cursorPosition - circlePosition;
            Speed = speedSaver;
        }     

        if(circlePosition.y + radius >= Height && movementDirection.y > 0  || circlePosition.y - radius <= 0 && movementDirection.y < 0)//Höjd
        {
            movementDirection.y *= -1;
        }
        if (circlePosition.x + radius >= Width && movementDirection.x > 0 || circlePosition.x - radius <= 0 && movementDirection.x <0) // Bredd
        {
            movementDirection.x *= -1;
        }
        
        circlePosition += Speed * Time.deltaTime * movementDirection;
        Circle(circlePosition.x, circlePosition.y, diameter);


    }
}
