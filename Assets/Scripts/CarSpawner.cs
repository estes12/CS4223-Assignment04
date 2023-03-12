using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnDelay = 2f;
    float nextTimeToSpawn;
    public GameObject car;
    public Transform[] spawnPoints;
    /*float countDownTimer = 3f;
     * In Update()
     * if (countDownTimer <= 0f)
     * {
     *      SpawnCar();
     *      countDownTimer = 3f;
     * }
     * else
     * {
     *      countDownTimer -= Time.deltaTime;
     * }*/
    void Start()
    {
        nextTimeToSpawn = MainMenu.spawnSpeed;
    }

    
    void Update()
    {
        if(nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
