using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretArmory : MonoBehaviour
{
    public GameObject bulletTypeBullet;
    public GameObject bulletTypeRocket;
    public float timer = 5f;
    public float fireRate = 5f;

    //Sprites
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    public Sprite[] spriteArray;

    //Audio
    [SerializeField]
    private AudioClip fireSoundRocket;
    [SerializeField]
    private AudioClip fireSoundBullet;
    private AudioSource audioSource;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void BulletTurret()
    {
        {
            //Set Sprite
            spriteRenderer.sprite = spriteArray[0];
            //Fire rate
            fireRate = 0.3f;
            //aim rotation
            Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
            transform.up = aim;

            //Fire
            if (Input.GetMouseButton(0) && timer > fireRate)
            {
                Instantiate(bulletTypeBullet, transform.position, transform.rotation);
                timer = 0;
                audioSource.PlayOneShot(fireSoundBullet, 1);
            }
            timer += Time.deltaTime;
        }
    }
    public void RocketTurret()
    {   if (fireRate <= timer)
        {
            spriteRenderer.sprite = spriteArray[2];
        }
        else
        {
            spriteRenderer.sprite = spriteArray[1];
        }
        //Fire rate
        fireRate = 2f;
        
        //aim rotation
        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        transform.up = aim;

        //Fire
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            Instantiate(bulletTypeRocket, transform.position, transform.rotation);
            timer = 0;
            audioSource.PlayOneShot(fireSoundRocket, 1);
        }
        timer += Time.deltaTime;
    }
}
   
   

