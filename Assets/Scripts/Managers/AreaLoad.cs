using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AreaLoad : MonoBehaviour
{
    [SerializeField]
    private string m_AreaToLoad;
    private bool m_PlayerInZone;
    public TextMeshProUGUI m_InteractText;
    // Start is called before the first frame update
    void Start()
    {
        m_InteractText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerInZone)
        {
            m_InteractText.enabled = true;

            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(m_AreaToLoad);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            m_PlayerInZone = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            m_PlayerInZone = false;
            m_InteractText.enabled = false;
        }
    }
}
