// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpSystemHealth : MonoBehaviour
// {
    
//     public GameObject PickUpItem;
//     public GameObject PickUpText;


//     void Start()
//     {
//         PickUpItem.SetActive(false);
//         PickUpText.SetActive(false);
//     }

//     private void OnTriggerStay(Collider other) 
//     {
//         PickUpText.SetActive(true);

//         if(other.gameObject.tag == "Player")
//         {
//             if (Input.GetKey(KeyCode.E))
//             {
//                 this.gameObject.SetActive(false);
//                 PickUpItem.SetActive(true);

//                 PickUpText.SetActive(false);
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other) 
//     {
//         PickUpText.SetActive(false);
//     }   
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpSystemHealth : MonoBehaviour
// {
//     // Amount of extra health to give
//     public int extraHealthAmount = 5; 
//     public GameObject PickUpItem;
//     public GameObject PickUpText;

//     private void Start()
//     {
//         PickUpItem.SetActive(true);
//         PickUpText.SetActive(false);
//     }

//     private void OnTriggerStay(Collider other)
//     {
//         PickUpText.SetActive(true);

//         if (other.gameObject.CompareTag("Player"))
//         {
//             if (Input.GetKey(KeyCode.E))
//             {
//                 ApplyExtraHealth(other.gameObject);

//                 this.gameObject.SetActive(true);
//                 PickUpItem.SetActive(false);
//                 PickUpText.SetActive(false);
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.gameObject.CompareTag("Player"))
//         {
//             PickUpText.SetActive(false);
//         }
//     }

//     private void ApplyExtraHealth(GameObject player)
//     {
//         PlayerHealthBar healthBar = player.GetComponent<PlayerHealthBar>();
//         if (healthBar != null)
//         {
//             if (healthBar.currentHealth < healthBar.maxHealth)
//             {
//                 int missingHealth = healthBar.maxHealth - healthBar.currentHealth;
//                 int extraHealth = Mathf.Min(extraHealthAmount, missingHealth);
//                 healthBar.IncreaseHealth(extraHealth);
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystemHealth : MonoBehaviour
{
    // Amount of extra health to give
    public int extraHealthAmount = 5; 
    public GameObject PickUpItem;

    public AudioSource collectSound;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectSound.Play();
            Destroy(gameObject);
            ApplyExtraHealth(other.gameObject);
        }
    }

    private void ApplyExtraHealth(GameObject player)
    {
        PlayerHealthBar healthBar = player.GetComponent<PlayerHealthBar>();
        if (healthBar != null)
        {
            if (healthBar.currentHealth < healthBar.maxHealth)
            {
                int missingHealth = healthBar.maxHealth - healthBar.currentHealth;
                int extraHealth = Mathf.Min(extraHealthAmount, missingHealth);
                healthBar.IncreaseHealth(extraHealth);
            }
        }
    }
}