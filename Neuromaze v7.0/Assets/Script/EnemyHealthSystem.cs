// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyHealthSystem : MonoBehaviour
// {
//    // public GameObject enemy;
//     public int maxHealth =100;
//     int currentHealth;
//     // Start is called before the first frame update
//     void Start()
//     {
//         currentHealth=maxHealth;
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth-=damage;
//         if(currentHealth<=0){
//             Die();
//         }


//     }

// void Die(){
//     Debug.Log("Enemy.Died!");
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyHealthSystem : MonoBehaviour
// {
//     public int maxHealth = 100;
//     [SerializeField] private int currentHealth;

//     public GameObject[] dropObjects; // Array of objects to potentially drop when the enemy dies
//     public float dropProbability = 1f; // Probability of dropping an object, ranging from 0 to 1
    
//     public AudioClip hitSound; // Sound effect when the enemy is hit
//     public GameObject deathSoundObject; // Game object to play sound after last hit

//     private AudioSource audioSource; // Reference to the AudioSource component

//     private bool isDead = false; // Flag indicating if the enemy is dead

//     private GameObject droppedObject; // Reference to the dropped object
//     private bool hasPlayedDeathSound = false; // Flag indicating if the death sound has been played

//     void Start()
//     {
//         currentHealth = maxHealth;

//         audioSource = GetComponent<AudioSource>();
//         if (audioSource == null)
//             audioSource = gameObject.AddComponent<AudioSource>();
//     }

//     void Update()
//     {
//         if (isDead)
//             return;

//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         Debug.Log("Enemy Health: " + currentHealth);

//         if (hitSound != null)
//         {
//             audioSource.PlayOneShot(hitSound);
//         }
//     }

//     void Die()
//     {
//         isDead = true;
//         Debug.Log("Enemy Died!");

//         if (!hasPlayedDeathSound && deathSoundObject != null)
//         {
//             // Instantiate the death sound object and play the sound
//             GameObject instantiatedDeathSoundObject = Instantiate(deathSoundObject, transform.position, transform.rotation);
//             AudioSource deathSoundAudioSource = instantiatedDeathSoundObject.GetComponent<AudioSource>();
//             if (deathSoundAudioSource != null)
//             {
//                 deathSoundAudioSource.Play();
//             }

//             hasPlayedDeathSound = true;
//         }

//         if (dropObjects != null && dropObjects.Length > 0 && Random.value <= dropProbability)
//         {
//             int randomIndex = Random.Range(0, dropObjects.Length);
//             GameObject dropObject = dropObjects[randomIndex];

//             if (dropObject != null)
//             {
//                 dropObject.SetActive(true);
//                 droppedObject = Instantiate(dropObject, transform.position, transform.rotation);
//             }
//         }

//         Destroy(gameObject);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;

    public GameObject[] dropObjects; // Array of objects to potentially drop when the enemy dies
    public float dropProbability = 1f; // Probability of dropping an object, ranging from 0 to 1
    
    public AudioClip hitSound; // Sound effect when the enemy is hit
    public GameObject deathSoundObject; // Game object to play sound after last hit

    private AudioSource audioSource; // Reference to the AudioSource component
    private EnemyHealthBar healthBar; // Reference to the EnemyHealthBar component

    private bool isDead = false; // Flag indicating if the enemy is dead

    private GameObject droppedObject; // Reference to the dropped object
    private bool hasPlayedDeathSound = false; // Flag indicating if the death sound has been played

    void Start()
    {
        currentHealth = maxHealth;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        healthBar = GetComponent<EnemyHealthBar>();
        if (healthBar == null)
            healthBar = gameObject.AddComponent<EnemyHealthBar>();

        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (isDead)
            return;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Health: " + currentHealth);

        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Enemy Died!");

        if (!hasPlayedDeathSound && deathSoundObject != null)
        {
            // Instantiate the death sound object and play the sound
            GameObject instantiatedDeathSoundObject = Instantiate(deathSoundObject, transform.position, transform.rotation);
            AudioSource deathSoundAudioSource = instantiatedDeathSoundObject.GetComponent<AudioSource>();
            if (deathSoundAudioSource != null)
            {
                deathSoundAudioSource.Play();
            }

            hasPlayedDeathSound = true;
        }

        if (dropObjects != null && dropObjects.Length > 0 && Random.value <= dropProbability)
        {
            int randomIndex = Random.Range(0, dropObjects.Length);
            GameObject dropObject = dropObjects[randomIndex];

            if (dropObject != null)
            {
                dropObject.SetActive(true);
                droppedObject = Instantiate(dropObject, transform.position, transform.rotation);
            }
        }

        Destroy(gameObject);
    }
}

