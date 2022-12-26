using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform            attackSensor;
    public LayerMask            attackMask;
    public float                attackRange = 0.5f;
    public int                  attackDamage = 10;
    public float                attackRate = 1f;
    float                       nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
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
