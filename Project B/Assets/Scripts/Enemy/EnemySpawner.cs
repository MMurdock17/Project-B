using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public float spawnCooldown = 10f;

    private float spawnTime;

    void Start()
    {
        spawnTime = spawnCooldown;
    }

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
