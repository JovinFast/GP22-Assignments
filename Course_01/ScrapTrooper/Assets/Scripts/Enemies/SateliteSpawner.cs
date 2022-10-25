using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteSpawner : MonoBehaviour
{
    public StandardSatelite satelitePrefab;
    [SerializeField]
    private float spawnRate = 2f;

    private float directionVariation = 15f;
    [SerializeField]
    public int amountToSpawn = 1;

    private float spawnDistance = 18f;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            //
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-directionVariation, directionVariation);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            StandardSatelite satelite = Instantiate(satelitePrefab, spawnPoint, rotation);
            satelite.size = Random.Range(satelite.minSize, satelite.maxSize);
            //Direction vector oposite to the vector that it spawned in
            satelite.SetDirection(rotation * -spawnDirection);
            
        }
    }
   
    
}
