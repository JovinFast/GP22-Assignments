using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweekExample : MonoBehaviour
{









    
    public GameObject laserPrefab;
    public float Speed = 1f;
    public float x = 0;
    public float y = 0;
    public float size = 1f;
    public float angle;
    public float fireRate = 0.2f;
    
    public float timer;

    // Update is called once per frame
    void Update()
    {
        //Fire laser



        if (Input.GetMouseButton(0) && timer > fireRate)
        {

            Instantiate(laserPrefab, transform.position, transform.rotation);
            timer = 80;

        }
        timer += Time.deltaTime;

        

        //Movement
        x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        y += Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        transform.position = new Vector3(x, y);

        //Scale
        if (Input.GetKeyDown(KeyCode.E))
        {
            size++;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            size--;
        }
        transform.localScale = Vector2.one * size;

        //Rotation
        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = aim;

        
    }


    private void Start()
    { 
        
    }

}
