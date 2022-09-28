using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtracurricularVectors : ProcessingLite.GP21
{
    public Vector2 randomLineStart;
    public Vector2 randomLineEnd;
    public float maxValue;
    private float minValue;
    private float randomX;
    private float randomY;
    private float randomX2;
    private float randomY2;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        randomX = Random.Range(0, Width);
        randomY = Random.Range(0, Height);
        randomX2 = Random.Range(0, Width);
        randomY2 = Random.Range(0, Width);
        randomLineStart.x = randomX;
        randomLineStart.y = randomY;
        randomLineEnd.x = randomX2;
        randomLineEnd.y = randomY2;

    }
}
