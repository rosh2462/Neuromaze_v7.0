using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public GameObject player;
    public int damageAmount = 10;
    public float damageInterval = 1f; // Time between each damage in seconds

    public AudioSource monsterBeating;

    private float damageTimer = 0f; // Timer to track the interval between damages

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float attackRange = 1f;

        if (distance <= attackRange)
        {
            // Check if enough time has passed since the last damage
            if (damageTimer <= 0f)
            {
                // Inflict damage to the player
                player.GetComponent<PlayerHealthBar>().TakeDamage(damageAmount);

                // Reset the timer
                damageTimer = damageInterval;
            }
            else
            {
                // Decrease the timer
                damageTimer -= Time.deltaTime;
            }

            if (monsterBeating != null)
            {
                 monsterBeating.Play(); // Play the game over sound effect
            }
        }
    }
}