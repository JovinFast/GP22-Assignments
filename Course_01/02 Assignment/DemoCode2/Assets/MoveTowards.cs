using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject followTarget;
    public bool _facingRight = false;
    float _moveSpeed = 1f;


    // Update is called once per frame
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
    
}
