using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public bool shieldDown;
    public float collisinTimeAmount = 1;
    public float onCollisionTimer = 1;
    [SerializeField]
    private PlayerManager playerManagerScript;
   
    Rigidbody2D rigidBody;
    [SerializeField]
    Collider2D triggerCollider;
    [SerializeField]
    Collider2D collidingCollider;

    SpriteRenderer thisSpriteRenderer;
    public void Awake()
    {
        shieldDown = false;
        rigidBody = GetComponent<Rigidbody2D>();
        playerManagerScript = GetComponent<PlayerManager>();
        
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (shieldDown == false)
            {
                collidingCollider.enabled = !collidingCollider.enabled;
                triggerCollider.enabled = !triggerCollider;
                thisSpriteRenderer.enabled = !thisSpriteRenderer.enabled;
                shieldDown = true;
                Debug.Log("ShieldBool: " + shieldDown);
            }
            else if (shieldDown == true)
            {
                collidingCollider.enabled = !collidingCollider.enabled;
                triggerCollider.enabled = !triggerCollider;
                thisSpriteRenderer.enabled = !thisSpriteRenderer.enabled;
                shieldDown = false;
                Debug.Log("ShieldBool: " + shieldDown);
            }

 
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Satelite")
    //    {
    //        onCollisionTimer -= 0.5f * Time.deltaTime;
    //        if (onCollisionTimer < 0)
    //        {
    //            gameObject.SetActive(false);
    //        }
            
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    onCollisionTimer = collisinTimeAmount;
    //}
}

