using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform            attackSensor;
    public float                attackRange = 0.5f;
    public LayerMask            attackMask;
    public int                  attackDamage = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    
    void Attack()
    {
        // Cast a circle forward to check for enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackSensor.position, attackRange, attackMask);

        // Damage all enemies that we found
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy hit!");
            enemy.GetComponent<Bandit>().ApplyDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackSensor == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackSensor.position, attackRange);
    }
}
