using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite, so we get access to all functions
class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    float size = 1f; //Ball size
    float radius;
    Vector3Int colourFill;
   

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)

    {
        
        colourFill.x = Random.Range(0, 255);
        colourFill.y = Random.Range(0, 255);
        colourFill.z = Random.Range(0, 255);
        
        Fill(colourFill.x, colourFill.y, colourFill.z, 255);
        //Set our position when we create the code.
        position = new Vector2(x, y);
        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
       
    }



    //Colour of ball
    public void ColourRandom ()
    {
        Fill (colourFill.x, colourFill.y, colourFill.z, 255);
    }

    //Size of ball
    public void Size()
    {
    size = Random.Range(0.3f, 2f);
        radius = size / 2;
    
    }


    //Ball bounce
    public void Bounce()
    {
        if (position.y + (size/2) >= Height && velocity.y > 0 || position.y - (size/2) <= 0 && velocity.y < 0)
        {
            velocity.y *= -1;
        }

        if (position.x + (size/2) >= Width && velocity.x > 0 || position.x - (size/2) <= 0 && velocity.x < 0)
        {
            velocity.x *= -1;
        }

    }


    //Draw our ball
    public void Draw()
    {

        
        Circle(position.x, position.y, size);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;
    }


    //Give position 
    public Vector2 GivePosition(Vector2 ballposition)
    {
    ballposition = position;
    return ballposition;
    }
    public bool CircleCollision(float x1, float y1, float size1, float x2, float y2)
    {
        float maxDistance = size1 + radius;


        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }

        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }

        else
        {
            return true;
        }
    }
}
