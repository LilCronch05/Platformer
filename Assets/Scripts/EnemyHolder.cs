using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject m_EnemyPrefab;
    [SerializeField]
    private GameObject m_EnemySpawnPoint;
    [SerializeField]
    private int m_NumberOfEnemiesTotal;
    [SerializeField]
    private int m_NumberOfEnemiesAtOnce;
    [SerializeField]
    private int m_NumberOfEnemiesSpawned;
    [SerializeField]
    private float m_TimeBetweenSpawns = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_EnemyPrefab == null)
        {
            Debug.Log("Enemy is dead");
        }

        if ((m_NumberOfEnemiesSpawned < m_NumberOfEnemiesAtOnce))
        {
            StartCoroutine(SpawnEnemy());  
        }

        if (m_NumberOfEnemiesSpawned == m_NumberOfEnemiesTotal)
        {
            StopCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        GameObject enemy = Instantiate(m_EnemyPrefab, m_EnemySpawnPoint.transform.position, Quaternion.identity);
        enemy.transform.parent = gameObject.transform;
        m_NumberOfEnemiesSpawned++;
        yield return new WaitForSeconds(m_TimeBetweenSpawns);
    }
}
