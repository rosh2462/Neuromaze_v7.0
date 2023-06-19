using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
    }
}
