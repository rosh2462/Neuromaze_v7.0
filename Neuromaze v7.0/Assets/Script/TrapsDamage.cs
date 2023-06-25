using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageInterval = 2f; // Time between each damage in seconds

    private float damageTimer = 0f; // Timer to track the interval between damages

    private void Update()
    {
        // Decrease the timer
        if (damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if enough time has passed since the last damage
            if (damageTimer <= 0f)
            {
                // Inflict damage to the player
                PlayerHealthBar playerHealthBar = other.GetComponent<PlayerHealthBar>();
                if (playerHealthBar != null)
                {
                    playerHealthBar.TakeDamage(damageAmount);
                }

                // Reset the timer
                damageTimer = damageInterval;
            }
        }
    }
}
