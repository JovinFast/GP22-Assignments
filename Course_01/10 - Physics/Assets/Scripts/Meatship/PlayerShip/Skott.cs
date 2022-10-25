using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skott : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        {
            GetComponent<Rigidbody2D>().velocity = transform.up * 10;
            Destroy(gameObject, 7);

        }
    }

   
}
