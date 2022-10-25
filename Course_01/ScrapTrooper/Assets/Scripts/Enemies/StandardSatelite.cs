using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardSatelite : MonoBehaviour
{
    [SerializeField]
    private GameObject coinDrop;
    
    private Rigidbody2D rigidBody;
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 5f;
    public float maxTimeAlive = 30;
    public float hP = 8f;
    private int minHp = 0;
    private void Awake()
    {
        
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.size;
        //mass, higher mass means slower
        rigidBody.mass = this.size;
    }
   //OnCollision  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hP -= 1;
        if (collision.gameObject.tag == "Bullet")
        {
            
            if (hP <= minHp)
            {
                
                int numberOfCoins = Random.Range(1, 4);
                for (int i = 0; i < numberOfCoins; i++)
                {
                    float coinSpread = Random.Range(0.1f, 0.4f);
                    Vector3 spawnpoint = new Vector3(transform.position.x + coinSpread, transform.position.y + coinSpread,0);
                    Instantiate(coinDrop, spawnpoint, transform.rotation);
                }
                
                Destroy(gameObject);
            }
        }
       
    }
    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "RocketExplosion")
        {

            hP *= -2 * Time.deltaTime;
            Debug.Log("Satelite HP : " + hP);
            if (hP <= minHp)
            {

                int numberOfCoins = Random.Range(1, 4);
                for (int i = 0; i < numberOfCoins; i++)
                {
                    float coinSpread = Random.Range(0.1f, 0.4f);
                    Vector3 spawnpoint = new Vector3(transform.position.x + coinSpread, transform.position.y + coinSpread, 0);
                    Instantiate(coinDrop, spawnpoint, transform.rotation);
                }

                Destroy(gameObject);
            }


        }
    }
    public void SetDirection(Vector2 direction)
    {
        rigidBody.AddForce(direction * speed);
        Destroy(this.gameObject, maxTimeAlive);
    }
}
