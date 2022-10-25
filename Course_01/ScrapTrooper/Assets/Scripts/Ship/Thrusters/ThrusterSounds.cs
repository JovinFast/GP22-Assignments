using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterSounds : MonoBehaviour
{
    public AudioSource source;
   
    private bool thrusting;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (thrusting)
        {
            source.enabled = true;
            source.loop = true;
           
        }
        if (!thrusting)
        {
            source.enabled = false;
            source.loop = false;
            
        }
    }
}

