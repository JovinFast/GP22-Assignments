using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public GameObject theShip; 
    private void Start()
    {       
        GetComponent<Rigidbody2D>().velocity = transform.up * 20;
        Destroy(this.gameObject, 7);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
