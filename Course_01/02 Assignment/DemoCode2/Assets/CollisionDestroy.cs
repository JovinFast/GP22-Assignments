using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        
        Destroy(col.gameObject);
        Debug.Log("Destroyed");
    }



}
