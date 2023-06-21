// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TriggerObject : MonoBehaviour
// {
//     public GameObject objectToEnable;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             objectToEnable.SetActive(true);
//         }
//     }
// }


// using UnityEngine;

// public class TriggerObject : MonoBehaviour
// {
//     public GameObject objectToEnable;
//     public AudioClip soundClip;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             objectToEnable.SetActive(true);
            
//             AttachAudioSource();
//             PlaySound();
//         }
//     }

//     private void AttachAudioSource()
//     {
//         if (objectToEnable.GetComponent<AudioSource>() == null)
//         {
//             AudioSource audioSource = objectToEnable.AddComponent<AudioSource>();
//             audioSource.playOnAwake = false;
//         }
//     }

//     private void PlaySound()
//     {
//         AudioSource audioSource = objectToEnable.GetComponent<AudioSource>();
//         if (audioSource != null && soundClip != null)
//         {
//             audioSource.clip = soundClip;
//             audioSource.Play();
//         }
//     }
// }


using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject objectToEnable;
    public AudioClip soundClip;

    private bool soundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !soundPlayed)
        {
            objectToEnable.SetActive(true);

            AttachAudioSource();
            PlaySound();

            soundPlayed = true;
        }
    }

    private void AttachAudioSource()
    {
        if (objectToEnable.GetComponent<AudioSource>() == null)
        {
            AudioSource audioSource = objectToEnable.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void PlaySound()
    {
        AudioSource audioSource = objectToEnable.GetComponent<AudioSource>();
        if (audioSource != null && soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}
