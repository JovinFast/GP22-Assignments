using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterFire : MonoBehaviour
{
    public SpriteRenderer rend;
   
    private bool thrusting = false;
   
    void Start()
    {
       
        rend = GetComponent<SpriteRenderer>();       
    }

   
    void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (thrusting)
        {
            
            rend.enabled = true;
        }
        if(!thrusting)
        {
            
            rend.enabled = false;
        }
    }
}
