  using UnityEngine;
  
   public class EnemyBehavior : MonoBehaviour
    {
        public float speed;

        private Transform player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's position        }
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

            // public void OnEnemyCollisionWithPlayer(GameObject player, Collision2D collision)

    // Debug.Log("Player collided with enemy: " + collision.gameObject.name);

    //         if (collision.gameObject.CompareTag("Enemy"))
    //         {
    //         ContactPoint2D contact = collision.contacts[0];
    //         Debug.Log("Collision point Y: " + contact.point.y + ", Enemy position Y: " + collision.gameObject.transform.position.y);

    //         if (contact.point.y > collision.gameObject.transform.position.y + 0.1f)
    //         {
    //         Debug.Log("Enemy stomped!");
    //         Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
    //         if (playerRb != null)
    //         {
    //             playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 10f); // Apply bounce
    //         }

    //         Destroy(collision.gameObject); // Destroy the enemy
    //         }
    //         else
    //         {
    //         Debug.Log("Player hit by enemy!");
    //         if (audioSource != null && deathSound != null)
    //         {
    //             audioSource.PlayOneShot(deathSound); // Play the death sound
    //         }

    //         // Add your respawn logic here if needed
    //          }
    }