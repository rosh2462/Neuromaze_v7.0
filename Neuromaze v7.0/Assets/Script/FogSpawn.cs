using UnityEngine;

public class FogSpawn : MonoBehaviour
{
    public GameObject particalSystem;
    private bool isObjectActive = true;
    
    private void Start()
    {
        // Start the timer
        InvokeRepeating("ParticalSystem", 0f, 10f);
    }
    
    private void ParticalSystem()
    {
        // Toggle the object's active state
        particalSystem.SetActive(isObjectActive);
        
        // Invert the active state for the next toggle
        isObjectActive = !isObjectActive;
    }
}
