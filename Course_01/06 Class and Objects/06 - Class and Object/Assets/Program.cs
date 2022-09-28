using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : ProcessingLite.GP21
{
    Player playerClass = new Player();
    
    //floats player
    public float teleportDistance = 0.1f;
    public float accelerationSpeed = 3;
    public float diameter = 2f;
    public float radius;
    public float speed = 3f;
    public float maxSpeed = 20f;
    public float decelerationSpeed = 3f;
    public float speedMin = 3f;
    string gameOverStr = "GAME OVER";
    //Vectors Player
    Vector3 playerCircle;
    Vector3 playerDirectionVector;
    //Balls
    public int numberOfBalls = 10;
    Ball[] balls;
    //collision
    bool collisionBool = false;
    Vector2 ballPosition;
    bool gameOver = false;
    string restartExplain = "Press R to Restart the game";
    string playerText = "Player";
    
    



    void Start()
    {
        
        balls = new Ball[numberOfBalls];
        playerCircle = playerClass.PlayerSpawnpoint(playerCircle);


            for (int i = 0; i < balls.Length; i++)
        {
            
            balls[i] = new Ball(Width / 2, Height - 1);
            balls[i].Size();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            //Background
            Stroke(0, 0, 0, 255);
            Background(50, 166, 240);

            float radius = playerClass.Radius(diameter);
            speed = playerClass.Acceleration(speed, accelerationSpeed);

            //loop for updating ball position
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].ColourRandom();
                balls[i].UpdatePos();
                balls[i].Draw();
                balls[i].Bounce();
                ballPosition = balls[i].GivePosition(ballPosition);
                //Collision
                collisionBool = balls[i].CircleCollision(playerCircle.x, playerCircle.y, radius, ballPosition.x, ballPosition.y);
                if (collisionBool == true)
                {
                    gameOver = true;
                }
            }



            
            

            //Movement
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) //Vid movement input gör detta
            {
                playerCircle = playerClass.PlayerMovement(playerCircle, speed);
                playerDirectionVector = playerClass.MovementDirection(playerDirectionVector);
            }
            //If no movement
            if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")) // With no input from movement do this
            {
                speed = playerClass.PlayerSlowDown(speed, speedMin, decelerationSpeed, playerCircle, teleportDistance);
                playerCircle = playerClass.PlayerMovementSlide(speed, playerCircle, speedMin, playerDirectionVector);
            }
            if (speed > maxSpeed)
                speed = maxSpeed;
            //Wrap
            playerCircle = playerClass.Wrap(playerCircle, radius);

            //Text on player
            Fill(0, 0, 0, 255);
            TextSize(40);
            Text(playerText, playerCircle.x, playerCircle.y);


            //Draw circles
            Fill(255,0, 0, 255);
            Circle(playerCircle.x, playerCircle.y, diameter);
            Circle(playerCircle.x + Width, playerCircle.y, diameter);
            Circle(playerCircle.x - Width, playerCircle.y, diameter);
        }

        if (gameOver == true)
        {
            
            //Background
            //G
            Background(255, 255, 255);

            Fill(73,221,232,255);
            TextSize(300);
            Text(gameOverStr, 8, 5);
            TextSize(100);
            Text(restartExplain, 8, 2);

            if (Input.GetKeyDown(KeyCode.R))
            {
                balls = new Ball[numberOfBalls];
                playerCircle = playerClass.PlayerSpawnpoint(playerCircle);


                for (int i = 0; i < balls.Length; i++)
                {

                    balls[i] = new Ball(Width / 2, Height - 1);
                    balls[i].Size();
                }
                gameOver = false;
            }

            
        }
    }
       
}
