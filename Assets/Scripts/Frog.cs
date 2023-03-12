using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource audioSource;

    public static int lives = 5;
    private int death;
    public int currentLives;
    public Text lifeDisplay;

    void Start()
    {
        currentLives = lives;
        DisplayLives();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            rb.MovePosition(rb.position + Vector2.right);

        if (Input.GetKeyDown(KeyCode.A))
            rb.MovePosition(rb.position + Vector2.left);

        if (Input.GetKeyDown(KeyCode.W))
            rb.MovePosition(rb.position + Vector2.up);

        if (Input.GetKeyDown(KeyCode.S))
            rb.MovePosition(rb.position + Vector2.down);

    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        death = lives;
        if (collision.tag == "Car")
        {           
            audioSource.Play();
            Debug.Log("You lost a life!");
            Score.score = 0;
            death--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else
        {
            audioSource.Pause();
            int num_scores = 10;        
            string path = "Assets/Resources/scores.txt";
            string line;
            string[] fields;
            int scores_written = 0;
            string newName = MainMenu.input;
            string newScore = Score.score.ToString();
            bool newScoreWritten = false;
            string[] writeNames = new string[10];
            string[] writeScores = new string[10];

            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                fields = line.Split(',');
                if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
                {
                    //check if we need to write new higher score first
                    if (Convert.ToInt32(newScore) > Convert.ToInt32(fields[1]))
                    {
                        writeNames[scores_written] = newName;
                        writeScores[scores_written] = newScore;
                        newScoreWritten = true;
                        scores_written += 1;
                    }

                }
                if (scores_written < num_scores) // we have not written enough lines yet
                {
                    writeNames[scores_written] = fields[0];
                    writeScores[scores_written] = fields[1];
                    scores_written += 1;
                }
            }
            reader.Close();

            // now we have parallel arrays with names and scores to write
            StreamWriter writer = new StreamWriter(path);

            for (int x = 0; x < scores_written; x++)
            {
                writer.WriteLine(writeNames[x] + ',' + writeScores[x]);
            }
            writer.Close();

            AssetDatabase.ImportAsset(path);
            TextAsset asset = (TextAsset)Resources.Load("scores");
            
        }
        lives = death;
        if(lives <= 0)
        {
            SceneManager.LoadScene(2);
            Debug.Log("You lost the game!");
        }
        if (Score.score >= 2000)
        {
            SceneManager.LoadScene(2);
            Debug.Log("You have won the game!");
        }
    }

    public void DisplayLives()
    {
        lifeDisplay.text = "Lives: " + currentLives.ToString();
    }

}

