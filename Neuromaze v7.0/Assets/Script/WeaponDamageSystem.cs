// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeaponDamageSystem : MonoBehaviour
// {
     
//    public Animator animator;
//    public Transform attackPoint;
//    public float attackRange = 0.5f;
//    public LayerMask enemyLayers;
//    public int attackDamage = 15;

//      void Update()
//     {

//         if (Input.GetMouseButtonDown(0))
//             {
//                 attack();
//             }
//     }

//     void attack()
//     {
//      animator.SetTrigger("PlayAnimation");

        
// Collider[] hitEnemies =  Physics.OverlapSphere(attackPoint.position,attackRange, enemyLayers);
    
//     foreach(Collider enemy in hitEnemies)
//     {
//         enemy.GetComponent<Enemy>().TakeDamage(attackDamage);   
//     }

//     }

// void OnDrawGizmosSelected(){ 
//        if(attackPoint==null)
//       return;
//         Gizmos.DrawWireSphere(attackPoint.position, attackRange);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageSystem : MonoBehaviour
{
     
   
   public Transform attackPoint;
   public float attackRange = 1f;
   public LayerMask enemyLayers;
   public int attackDamage = 15;

     void Update()
    {

        if (Input.GetMouseButtonDown(0))
            {
                attack();
            }
    }

    void attack()
    {
        
Collider[] hitEnemies =  Physics.OverlapSphere(attackPoint.position,attackRange, enemyLayers);
    
    foreach(Collider EnemyHealthSystem in hitEnemies)
    {
        EnemyHealthSystem.GetComponent<EnemyHealthSystem>().TakeDamage(attackDamage);   
    }

    }

void OnDrawGizmosSelected(){ 
       if(attackPoint==null)
      return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


