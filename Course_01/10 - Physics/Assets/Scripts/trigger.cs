using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


         //g�r ej if other.tag == player f�r det �r l�ngsamare
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(-7, 3);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(-7, 3);
        }
    }
}
