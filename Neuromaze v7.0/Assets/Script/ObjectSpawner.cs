
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 10f;
    public int spawnNumber = 5; 
    public Vector3 spawnRotation = Vector3.zero; 
    public GameObject particleSystemPrefab;
    public float delayAfterParticleSystem = 2.1f; // Delay in seconds after the particle system starts before the object appears

    private void Start()
    {
        if (spawnNumber > 0)
        {
            // Spawn the first object immediately
            SpawnObject();
            
            // Start spawning objects with the given interval, but only if spawnNumber is greater than 1
            if (spawnNumber > 1)
            {
                InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
            }
        }
    }

    private void SpawnObject()
    {
        // Instantiate the particle system prefab
        GameObject particleSystemObject = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

        // Invoke the method to spawn the object with the specified delay
        Invoke("InstantiateObject", delayAfterParticleSystem);
    }

    private void InstantiateObject()
    {
        // Instantiate the object prefab
        GameObject spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.Euler(spawnRotation));

        // Decrease the count of objects to spawn
        spawnNumber--;

        // If all objects have been spawned, cancel the spawning
        if (spawnNumber <= 0)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
