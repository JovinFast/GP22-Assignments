using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatship : MonoBehaviour
{
    public GameObject skottPrefab;
    private Rigidbody2D _rigidbody;
    private float x = 0;
    private float y = 0;
    public float Speed = 2;
    public float timer;
    public float fireRate;
    public bool docked = false;

   
    [SerializeField]
    private int playerHPint;
    public float playerHp = 100;

    //Sound
    [SerializeField]
    private AudioClip fireSound;

    private AudioSource audioSource;

    private void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerHPint = Mathf.RoundToInt(playerHp);
        //Movement
        if (docked == false)
        {
            x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            y += Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        }
       

        

        transform.position = new Vector3(x, y);
        //Rotation
        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = aim;

        //Fire
        if (Input.GetMouseButton(0) && timer > fireRate)
        {

            Instantiate(skottPrefab, transform.position, transform.rotation);
            timer = 0;
            audioSource.PlayOneShot(fireSound,1);
        }
        timer += Time.deltaTime;
        
    }
}

