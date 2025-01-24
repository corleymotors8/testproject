using UnityEngine;

public class EnemySpawner : MonoBehaviour  
{
    public int numberSpawns = 0;
    public int maxSpawns = 1; 
    public GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(Bounds bounds)
    {
            // Spawn enemy at the right edge
            Vector3 spawnPosition = new Vector3(bounds.max.x - 1.0f, bounds.center.y + 1.0f, transform.position.z);

            // Instantiate the enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }


}
