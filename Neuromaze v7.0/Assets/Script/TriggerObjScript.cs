using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjScript : MonoBehaviour
{
   public GameObject adBoard; //Create reference to other script
   public Animator animator;
   void OnTriggerEnter(Collider other) 
   {
      
      adBoard.SetActive(true);
      // Debug.Log("Trueee");
      animator.SetTrigger("Playattack");


   }
}
