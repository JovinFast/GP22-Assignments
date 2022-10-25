using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{   
    
    private Collider2D thisCollider;
    [SerializeField]
    private StatsHandler statsHandler;
    void Awake()
    {
        
        thisCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            statsHandler.coins+=1;
            Debug.Log(statsHandler.coins);
            Destroy(this.gameObject);
        }
    }
} 
