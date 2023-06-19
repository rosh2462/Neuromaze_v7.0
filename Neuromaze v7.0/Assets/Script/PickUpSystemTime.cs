// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpSystemTime : MonoBehaviour
// {
//     // Amount of extra time to give
//     public float extraTimeAmount = 20f; 
//     public GameObject PickUpItem;
//     public GameObject PickUpText;

//     public delegate void PickUpAction(float extraTime);
//     public static event PickUpAction OnPickUp;

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
//                 ApplyExtraTime();

//                 this.gameObject.SetActive(false);
//                 PickUpItem.SetActive(false);

//                 PickUpText.SetActive(false);
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         PickUpText.SetActive(false);
//     }

//     private void ApplyExtraTime()
//     {
//         OnPickUp?.Invoke(extraTimeAmount);
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpSystemTime : MonoBehaviour
// {
//     // Amount of extra time to give
//     public float extraTimeAmount = 20f; 
//     public GameObject PickUpItem;
    
//     public delegate void PickUpAction(float extraTime);
//     public static event PickUpAction OnPickUp;

//     public AudioSource collectSound;

   
//     private void OnTriggerEnter(Collider other)
//     {
//         collectSound.Play();
//         Destroy(gameObject);
//         ApplyExtraTime();
//     }

//     private void ApplyExtraTime()
//     {
//         OnPickUp?.Invoke(extraTimeAmount);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystemTime : MonoBehaviour
{
    // Amount of extra time to give
    public float extraTimeAmount = 20f; 
    public GameObject PickUpItem;
    
    public delegate void PickUpAction(float extraTime);
    public static event PickUpAction OnPickUp;

    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectSound.Play();
            Destroy(gameObject);
            ApplyExtraTime();
        }
    }

    private void ApplyExtraTime()
    {
        OnPickUp?.Invoke(extraTimeAmount);
    }
}
