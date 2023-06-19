using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 

    private void Update()
    {
       
        Vector3 direction = player.position - transform.position;
        direction.Normalize(); 

        
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

       
        transform.Translate(movement);
    }
}
