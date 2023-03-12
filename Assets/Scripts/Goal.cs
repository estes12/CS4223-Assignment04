using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{


    void OnTriggerEnter2D()
    {
        Debug.Log("You beat the level!");
        Score.score += 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
