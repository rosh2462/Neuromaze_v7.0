
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeedX = 60f;

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeedX * Time.deltaTime);
    }
}
