using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komet : MonoBehaviour
{
    [SerializeField]
    private AudioClip impactSound;
    [SerializeField]
    private AudioClip gameOverSound;
    public GameObject followTarget;
    public bool _facingRight = false;
    public float _moveSpeed = 1f;
    public int hp = 3;
    public float size = 1f;
    public bool makeSound;
    
    private void Start()
    {
        transform.localScale = Vector2.one * size;
        followTarget = GameObject.FindGameObjectWithTag("Player");
    }

    //Movement
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, followTarget.transform.position, _moveSpeed * Time.deltaTime);
        if (followTarget.transform.position.x < gameObject.transform.position.x && _facingRight)
        {
            flip();
        }

        if (followTarget.transform.position.x > gameObject.transform.position.x && !_facingRight)
        {
            flip();
        }
    }
    private void flip()
    {
        _facingRight = !_facingRight;

        //assigns a the scale component to a variable temporarily
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
    
    //Hp och storlek
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 1;
            _moveSpeed += 2f;
            size -= 0.4f;
            transform.localScale = Vector2.one * size;

            if (hp < 0f)
            {

                Destroy(gameObject);
            }
            
        }
        //Destroy bullet on impact
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(impactSound, new Vector3(0,0,0));
            Destroy(collision.gameObject);
            Debug.Log("destroyed");
            
        }
    }
    
}
