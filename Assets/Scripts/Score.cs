using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    void Start()
    {
        scoreText.text = score.ToString();
    }

   
    void Update()
    {
        
    }
}
