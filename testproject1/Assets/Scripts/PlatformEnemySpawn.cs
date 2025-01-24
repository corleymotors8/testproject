using UnityEngine;

public class PlatformEnemySpawn : MonoBehaviour
{
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script

    private int numberSpawns = 0; // Enemy spawn counter
    public int maxSpawns = 1; // Maximum number of enemy spawns
    public float enemySpeed = 5f; // Speed for the enemy
    public AudioClip deathSound; // Death sound for the player
    public CameraMover cameraMover; // Reference to the CameraMover script

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component on this GameObject
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if not present
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && numberSpawns < maxSpawns)
        {
            Bounds b = GetComponent<Collider2D>().bounds; // Get the bounds of the platform
            enemySpawner.SpawnEnemy(b); // Call the SpawnEnemy method from the EnemySpawner script
            // Increment enemy spawn count
            numberSpawns++;
        }
    }
}

    


