using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSounds : MonoBehaviour


{
    //Audio
    [SerializeField]
    private AudioClip deadSound;
    private AudioSource audioSource;
    [SerializeField]
    PlayerMovement playerScript;


    int playerHitSound;
    void Awake()
    {
       
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        playerHitSound = playerScript.playerHitsound;
    }
    // Update is called once per frame
    void Update()
    {
        if(playerScript.playerHitsound > playerHitSound)
        {
            audioSource.PlayOneShot(deadSound);
            playerHitSound++;
        }
    }
}
