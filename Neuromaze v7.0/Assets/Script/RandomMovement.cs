using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // The movement speed of the monster

    private Rigidbody monsterRigidbody;
    private Vector3 movementDirection;

    private void Awake()
    {
        monsterRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get the input for movement from the player (e.g., arrow keys or WASD)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input
        movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        // Move the monster based on the movement direction
        monsterRigidbody.velocity = movementDirection * moveSpeed;
    }
}

