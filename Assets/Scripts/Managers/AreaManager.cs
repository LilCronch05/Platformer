using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField]
    private Transform m_PlayerSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = m_PlayerSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
