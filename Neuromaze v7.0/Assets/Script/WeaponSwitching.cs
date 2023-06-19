// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeaponSwitching : MonoBehaviour
// {

//     public int selectedWeapon = 0;
//     // Start is called before the first frame update
//     void Start()
//     {
//         SelectWeapon();
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         int previousSelectedWeapon = selectedWeapon;

//         if (Input.GetAxis("Mouse ScrollWheel") > 0f)
//         {
//             if(selectedWeapon >= transform.childCount - 1)
//                 selectedWeapon = 0;
//             else
//                 selectedWeapon++;
//         }

//         if (Input.GetAxis("Mouse ScrollWheel") <     0f)
//         {
//             if(selectedWeapon <= 0)
//                 selectedWeapon = transform.childCount - 1;
//             else
//                 selectedWeapon--;
//         }

//         if (Input.GetKeyDown(KeyCode.Alpha1))
//         {
//             selectedWeapon = 0;
//         }

//         if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
//         {
//             selectedWeapon = 1;
//         }

//         if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
//         {
//             selectedWeapon = 2;
//         }

//         if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
//         {
//             selectedWeapon = 3;
//         }

//         if (previousSelectedWeapon != selectedWeapon)
//         {
//             SelectWeapon();
//         }
        
//     }

//     void SelectWeapon()
//     {
//         int i = 0;
//         foreach (Transform weapon in transform)
//         {
//             if(i == selectedWeapon)
//                 weapon.gameObject.SetActive(true);
//             else
//                 weapon.gameObject.SetActive(false);
//             i++;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public AudioClip weaponSwitchSoundClip; // Sound clip for weapon switch sound effect
  //public Sprite[] weaponIcons;
    [SerializeField] private Image[] weaponIconImages;
    private AudioSource weaponSwitchAudioSource; // Audio source for playing the sound effect

    void Start()
    {
        weaponSwitchAudioSource = gameObject.AddComponent<AudioSource>();
        weaponSwitchAudioSource.playOnAwake = false;
        weaponSwitchAudioSource.clip = weaponSwitchSoundClip;

        SelectWeapon();
        UpdateWeaponIcons();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;

            PlayWeaponSwitchSound();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;

            PlayWeaponSwitchSound();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (selectedWeapon != 0)
            {
                selectedWeapon = 0;
                PlayWeaponSwitchSound();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            if (selectedWeapon != 1)
            {
                selectedWeapon = 1;
                PlayWeaponSwitchSound();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            if (selectedWeapon != 2)
            {
                selectedWeapon = 2;
                PlayWeaponSwitchSound();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            if (selectedWeapon != 3)
            {
                selectedWeapon = 3;
                PlayWeaponSwitchSound();
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
            UpdateWeaponIcons();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void UpdateWeaponIcons()
    {
        for (int i = 0; i < weaponIconImages.Length; i++)
        {
            if (i == selectedWeapon)
            {
                weaponIconImages[i].gameObject.SetActive(true);
            }
            else
            {
                weaponIconImages[i].gameObject.SetActive(false);
            }
        }
    }

    void PlayWeaponSwitchSound()
    {
        if (weaponSwitchAudioSource != null && weaponSwitchSoundClip != null)
        {
            weaponSwitchAudioSource.PlayOneShot(weaponSwitchSoundClip);
        }
    }
}
