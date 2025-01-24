using UnityEngine;

public class PlatformEnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
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
        if (collision.gameObject.CompareTag("Player") & numberSpawns < maxSpawns)
        {
            // Get platform bounds
            Bounds bounds = GetComponent<Collider2D>().bounds;

            // Change platform color
            // GetComponent<SpriteRenderer>().color = Color.red;

            // Spawn enemy at the right edge
            Vector3 spawnPosition = new Vector3(bounds.max.x - 1.0f, bounds.center.y + 1.0f, transform.position.z);

            // Instantiate the enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Increment enemy spawn count
            numberSpawns++;

            // Assign enemy behavior dynamically
            EnemyBehavior enemyBehavior = enemy.AddComponent<EnemyBehavior>();
            enemyBehavior.speed = enemySpeed;

            // Set the camera's new position
            if (cameraMover != null)
            {
                cameraMover.SetTargetPosition(new Vector3(100f, 55f, -10f)); 
            }
        }
            
    }
    

    public void OnEnemyCollisionWithPlayer(GameObject player, Collision2D collision)
{
    Debug.Log("Player collided with enemy: " + collision.gameObject.name);

    if (collision.gameObject.CompareTag("Enemy"))
    {
        ContactPoint2D contact = collision.contacts[0];
        Debug.Log("Collision point Y: " + contact.point.y + ", Enemy position Y: " + collision.gameObject.transform.position.y);

        if (contact.point.y > collision.gameObject.transform.position.y + 0.1f)
        {
            Debug.Log("Enemy stomped!");
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 10f); // Apply bounce
            }

            Destroy(collision.gameObject); // Destroy the enemy
        }
        else
        {
            Debug.Log("Player hit by enemy!");
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound); // Play the death sound
            }

            // Add your respawn logic here if needed
        }
    }
}
}

    public class EnemyBehavior : MonoBehaviour
    {
        public float speed;

        private Transform player;
        private PlatformEnemySpawn platformScript;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's position
            platformScript = FindFirstObjectByType<PlatformEnemySpawn>(); // Reference the main script
        }

        void Update()
        {
            // Move toward the player
            if (player != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)direction * speed * Time.deltaTime;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                platformScript.OnEnemyCollisionWithPlayer(collision.gameObject, collision); // Trigger player death logic
            }
        }
    }


