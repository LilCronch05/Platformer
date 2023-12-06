using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform patrolPointA;
    public Transform patrolPointB;
    public float m_moveSpeed = 2f;
    public float m_chaseDistance = 5f;
    public float m_attackDistance = 1.5f;

    private Transform m_target;
    private bool isChasing = false;
    private bool isAttacking = false;
    private bool isMovingTowardsA = true;

    private SpriteRenderer m_spriteRenderer;

    void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isChasing)
        {
            Chase();
        }
        else
        {
            Patrol();
        }

        UpdateAnimations();
    }

    void Patrol()
    {
        if (isMovingTowardsA)
        {
            transform.Translate(Vector2.left * m_moveSpeed * Time.deltaTime);
            FlipSpriteIfNeeded(patrolPointA.position.x);
            if (transform.position.x < patrolPointA.position.x)
                isMovingTowardsA = false;
        }
        else
        {
            transform.Translate(Vector2.right * m_moveSpeed * Time.deltaTime);
            FlipSpriteIfNeeded(patrolPointB.position.x);
            if (transform.position.x > patrolPointB.position.x)
                isMovingTowardsA = true;
        }

        CheckChaseCondition();
    }

    void Chase()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, m_target.position);

        if (distanceToPlayer > m_attackDistance)
        {
            transform.Translate((m_target.position - transform.position).normalized * m_moveSpeed * Time.deltaTime);
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }
    }

    void CheckChaseCondition()
    {
        if (Vector2.Distance(transform.position, m_target.position) < m_chaseDistance)
        {
            isChasing = true;
            isMovingTowardsA = false;
        }
        else
        {
            isChasing = false;
            isAttacking = false;
        }
    }

    void UpdateAnimations()
    {
        // Implement animation updates here if needed

    }

    void FlipSpriteIfNeeded(float targetX)
    {
        if (transform.position.x < targetX)
            m_spriteRenderer.flipX = true;
        else
            m_spriteRenderer.flipX = false;
    }
}