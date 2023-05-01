using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject player;
    private Vector2 player_prev_position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) != 0.0f)
         {
             Vector2 delta_position;
             delta_position = (Vector2) player.transform.position - player_prev_position;
             transform.Translate(delta_position);
         }
         player_prev_position = player.transform.position;
    }
}
