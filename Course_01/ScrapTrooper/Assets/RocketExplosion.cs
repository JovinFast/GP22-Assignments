using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    [SerializeField]
    private AudioClip explosionSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        audioSource.PlayOneShot(explosionSound);
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale += new Vector3(1 * Time.deltaTime, 1 * Time.deltaTime, 0);
    }
}
