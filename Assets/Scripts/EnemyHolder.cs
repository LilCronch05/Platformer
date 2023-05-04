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
    [Range(0, 20)]
    private int m_NumberOfEnemiesSpawned;
    [SerializeField]
    private int m_NumberOfEnemiesTotal;
    [SerializeField]
    private int m_NumberOfEnemiesAtOnce;

    [SerializeField]
    private float m_TimeBetweenSpawns;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(SpawnEnemy(m_NumberOfEnemiesSpawned, m_TimeBetweenSpawns));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy(int qty, float spwnRte)
    {
        for (int i = 0; i < qty; i++)
        {
            GameObject enemy = Instantiate(m_EnemyPrefab, m_EnemySpawnPoint.transform.position, Quaternion.identity);
            enemy.gameObject.transform.SetParent(m_EnemySpawnPoint.transform);
            enemy.transform.position = m_EnemySpawnPoint.transform.position;
            yield return new WaitForSeconds(spwnRte);
        }
        yield return null;
    }
}
