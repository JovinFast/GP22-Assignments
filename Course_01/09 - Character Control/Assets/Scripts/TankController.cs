using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    private float angle;
    public float turningSpeed = 90;
    public float speed = 5;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;

        rb2d.MoveRotation(angle);

        float y = Input.GetAxis("Vertical");

        rb2d.velocity = rb2d.transform.up * y * speed;

    }
}
