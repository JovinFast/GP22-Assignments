using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    public float x;
    public float y;
    public float diameter = 0.2f;
    public float diameterO = 30f;
    public float spaceBetweenLines = 0.2f;
    public float spaceBetweenLinesParabolic = 0.2f;
    private void Start()
    {
        Application.targetFrameRate = 5;
    }

    void Update()
    {
        //Clear background
        Background(240, 166, 50);


        //Test för kordinatförståelse
        //Circle(x, y, diameter); 
        //Line(a,b,c,d);


        //Prepare our stroke settings
        Stroke(0, 0, 0, 255);
        StrokeWeight(2.4f);
        //J



        Line(5f,8f,3f,8f);
        Line(5f,8f,5f,5f);
        Line(5f, 5f, 4f, 4f);
        Line(3f, 5f, 4f, 4f);

        //O
        Fill(240, 166, 50, 255);
        Circle(7f,6f,3);

        //V
        Line(9,8f,10f,4f);
        Line(11, 8f, 10f, 4f);

        //I
        Line(12, 8, 12, 4f);

        //N
        Line(13, 8, 13, 4);
        Line(13, 8, 14, 4);
        Line(14, 8, 14, 4);


        //Rektangel
        Stroke(240, 90, 70, 255);
        StrokeWeight(1f);
        //Draw our art/stuff, or in this case a rectangle
        Fill(240,200,50,255);
        Rect(3, 4, 14, 3);
        NoFill();
        Rect(1,16,18,2);

        //Prepare our stroke settings
        Stroke(128, 244, 128, 64);
        StrokeWeight(0.5f);

        //Draw our scan lines
        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {
            //Increase y-cord each time loop run
            float y = i * spaceBetweenLines;

            //Draw a line from left side of screen to the right
            Line(0, y, Width, y);
        }

        //Parabolic Curves
        Stroke(0, 0, 0, 120);
        StrokeWeight(1f);

        spaceBetweenLinesParabolic = Mathf.Sin(Time.time) + 1.2f;
        
        

        //Line(0,10,1,0);
        for (int i = 0; i < Height/spaceBetweenLinesParabolic; i++)
        {

            if(i %3 == 0)
            {
                int r = Random.Range(160, 256);
                int g = Random.Range(0, 70);
                int b = Random.Range(0, 150);
                Stroke(r,g,b);
            }
                     
            Line(0, Height- i * spaceBetweenLinesParabolic, Width * i /(Height/spaceBetweenLinesParabolic), 0 );
        }
        
    }


}
