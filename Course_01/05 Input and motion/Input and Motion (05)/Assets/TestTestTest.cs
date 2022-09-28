using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTestTest : ProcessingLite.GP21
{
    Vector2 playerPosition;
    float diameter = 2;
    float speed = 0.05f;

    void Start()
    {
        playerPosition.x = Width / 2;
        playerPosition.y = Height / 2;

    }

    void Update()
    {
        Background(50, 166, 240);

        //add our new input to our x position
        playerPosition.x += Input.GetAxis("Horizontal") * speed;
        playerPosition.y += Input.GetAxis("Vertical") * speed;
        Circle(playerPosition.x, playerPosition.y, diameter);
    }
}
