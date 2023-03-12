using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public InputField playerInput;
    public static string input;
    public Text playerName;

    public Slider carSpeedSlider;
    public static float carSpeed = 8f;
    public Text showCarSpeed;

    public Slider spawnSpeedSlider;
    public static float spawnSpeed = 0f;
    public Text showSpawnSpeed;
    public void PlayerName()
    {
        input = playerInput.text;
        playerName.text = input;
    }

    public void DisplayName()
    {
        playerName.text = input;
    }

    public void CarSpeed()
    {
        carSpeed = carSpeedSlider.value;
    }
    public void ShowCarSpeed()
    {
        showCarSpeed.text = "Car Speed: " + carSpeed.ToString();
    }

    public void CarSpawnSpeed()
    {
        spawnSpeed = spawnSpeedSlider.value;
    }
    public void ShowSpawnSpeed()
    {
        showSpawnSpeed.text = "Car Spawn Speed: " + spawnSpeed.ToString();
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        spawnSpeed = spawnSpeedSlider.value;
        CarSpawnSpeed();
        carSpeed = carSpeedSlider.value;
        CarSpeed();
    }


    void Update()
    {
        
    }
}
