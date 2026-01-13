using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    public float timer;
    public float intervalSpawn = 2f;

    public GameObject[] obstacles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;
        
        // Condition pour spawn quand le timer atteint le temps de spawn
        if(timer >= intervalSpawn)
        {
            print("Spawn !");
            timer = 0; // Remet le timer à zéro
            
            // Génération aléatoire d'un obstacle
            int randomIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
        }

    }
}
