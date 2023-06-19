using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 1f;
    public int spawnNumber = 5; 
    public Vector3 spawnRotation = Vector3.zero; 
    public GameObject particleSystemPrefab;
    public float delayAfterParticleSystem = 2.1f; // Delay in seconds after the particle system starts before the object appears

    private void Start()
    {
        // Start spawning objects with the given interval
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
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





//SPAWNING OBJECTS EACH TIME WHEN ANOTHER ONE DESTROYED

// using UnityEngine;

// public class ObjectSpawner : MonoBehaviour
// {
//     public GameObject objectPrefab;
//     public float spawnInterval = 1f;
//     public int spawnNumber = 5;
//     public Vector3 spawnRotation = Vector3.zero;
//     public GameObject particleSystemPrefab;
//     public float delayAfterParticleSystem = 2.1f; // Delay in seconds after the particle system starts before the object appears

//     private bool isObjectSpawned = false;

//     private void Start()
//     {
//         // Start spawning objects with the given interval
//         InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
//     }

//     private void SpawnObject()
//     {
//         // Check if an object is already spawned
//         if (isObjectSpawned)
//         {
//             return;
//         }

//         // Instantiate the particle system prefab
//         GameObject particleSystemObject = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

//         // Invoke the method to spawn the object with the specified delay
//         Invoke("InstantiateObject", delayAfterParticleSystem);
//     }

//     private void InstantiateObject()
//     {
//         // Instantiate the object prefab
//         GameObject spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.Euler(spawnRotation));

//         // Set the flag to indicate that an object is spawned
//         isObjectSpawned = true;

//         // Decrease the count of objects to spawn
//         spawnNumber--;

//         // If all objects have been spawned, cancel the spawning
//         if (spawnNumber <= 0)
//         {
//             CancelInvoke("SpawnObject");
//         }

//         // Add a script to the spawned object to notify the spawner when it's destroyed
//         ObjectDestroyedNotifier notifier = spawnedObject.AddComponent<ObjectDestroyedNotifier>();
//         notifier.Spawner = this;
//     }

//     // Add a method to reset the flag when the object is destroyed
//     public void ObjectDestroyed()
//     {
//         isObjectSpawned = false;
//     }
// }

// public class ObjectDestroyedNotifier : MonoBehaviour
// {
//     public ObjectSpawner Spawner;

//     private void OnDestroy()
//     {
//         if (Spawner != null)
//         {
//             Spawner.ObjectDestroyed();
//         }
//     }
// }
