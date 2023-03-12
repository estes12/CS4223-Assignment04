using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    static double gameTime;
    bool gameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = Time.deltaTime;

        if(gameTime == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if (gameEnd == false)
        {
            gameEnd = true;
            Debug.Log("GAME OVER");            
        }
    }
}
