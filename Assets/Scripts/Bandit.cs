using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private EnemyController m_movementScript;

    private Animator m_animator;

    private bool m_grounded = false;
    private bool m_combatIdle = false;
    private bool m_isDead = false;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        m_movementScript = GetComponent<EnemyController>();

        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        // Add damage effects or feedback as needed
        m_animator.SetTrigger("Hurt");
    }

    void Die()
    {
        // Death logic
        // You can play death animation, disable collider, or destroy the GameObject
        m_animator.SetTrigger("Death");
        m_isDead = true;

        //Disable enemy
        this.enabled = false;
        Destroy(gameObject, 2.5f);

        //Stop movement
        m_movementScript.enabled = false;
    }
}
