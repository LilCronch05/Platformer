using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;
    [SerializeField]
    private GameObject m_PlayerCamera;
    public static GameManager gmInstance = null;
    //public GameData gameData;

    private void Awake()
    {
        //gameData = new GameData();

        if (gmInstance == null)
        {
            gmInstance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(m_Player);
            DontDestroyOnLoad(m_PlayerCamera);
        }
        else if (gmInstance != this)
        {
            Destroy(gameObject);
            Destroy(m_Player);
            Destroy(m_PlayerCamera);
        }
    }
}
