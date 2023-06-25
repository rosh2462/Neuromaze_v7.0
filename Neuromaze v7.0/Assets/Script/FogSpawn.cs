using UnityEngine;

public class FogSpawn : MonoBehaviour
{
    public GameObject particalSystem;
    private bool isObjectActive = true;

    public float startTime = 0f;
    public float intervalTime = 10f;
    
    private void Start()
    {
        // Start the timer
        InvokeRepeating("ParticalSystem", startTime, intervalTime);
    }
    
    private void ParticalSystem()
    {
        // Toggle the object's active state
        particalSystem.SetActive(isObjectActive);
        
        // Invert the active state for the next toggle
        isObjectActive = !isObjectActive;
    }
}
