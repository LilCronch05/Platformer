using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance = null;
    //public GameData gameData;

    private void Awake()
    {
        //gameData = new GameData();

        if (gmInstance == null)
        {
            gmInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gmInstance != this)
        {
            Destroy(gameObject);
        }
    }
}
