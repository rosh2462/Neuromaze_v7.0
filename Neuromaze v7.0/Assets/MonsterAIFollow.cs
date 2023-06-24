using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.5f;
    public float rotationSpeed = 0.5f;
    public float raycastDistance = 1f;

    private Vector3 targetPosition;
    private bool isTurning = false;

    void Start()
    {
        SetNewTargetPosition();
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 1f)
            {
                // Player is close, stop moving
                return;
            }

            if (isTurning)
            {
                // Rotate towards the target position
                Vector3 direction = targetPosition - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                return;
            }

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check for collision with walls
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    // Hit a wall, start turning
                    isTurning = true;
                }
            }

            // Check if reached the current target position
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
            {
                // Reached the current target position, set a new one
                SetNewTargetPosition();
            }
        }
    }

    void SetNewTargetPosition()
    {
        // Set a new random target position near the player
        float targetRadius = 5f;
        Vector3 randomOffset = Random.insideUnitCircle * targetRadius;
        targetPosition = player.transform.position + new Vector3(randomOffset.x, 0f, randomOffset.y);
        isTurning = false;
    }
}
