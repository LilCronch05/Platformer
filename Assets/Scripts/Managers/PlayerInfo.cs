using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PlayerCamera;
    public static PlayerInfo piInstance = null;
    public Vector3 spawnLocation;
    public string currentScene;

    private void Awake()
    {
        if (piInstance == null)
        {
            piInstance = this;
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(m_PlayerCamera);
        }
        else if (piInstance != this)
        {
            Destroy(gameObject);
            Destroy(m_PlayerCamera);
        }
    }
}
