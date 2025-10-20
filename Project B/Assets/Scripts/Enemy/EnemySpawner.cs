using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //variables
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public float spawnCooldown = 10f;

    private float spawnTime;

    //setting intial spawn time
    void Start()
    {
        spawnTime = spawnCooldown;
    }

    //spawntime goes down until an enemy spawns at a random spawn point; spawn time resets
    void Update()
    {
       
        spawnTime -= Time.deltaTime;
       
        if (spawnTime <= 0)
        {
            int randomEnemy = Random.Range(0, enemies.Length);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, transform.rotation);

            spawnTime = spawnCooldown;
        }
    }

}
