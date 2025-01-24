using UnityEngine;

public class Player : MonoBehaviour
{
   // Set the speed and jumping variables
   public float speed = 5.0f;
   public float jumpForce = 10.0f;
   public float doubleJumpForce = 60.0f;
   private int jumpcount = 0;

   public GameObject playerPrefab; // Reference to the player prefab
   public float respawnYOffset = 300f; // Vertical offset for respawning above the platform

   private Rigidbody2D rb;

   private GameObject lastPlatform;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has fallen off the screen
        float bottomEdgeY = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.nearClipPlane)).y;

        if (transform.position.y < bottomEdgeY)
        {
        Debug.Log("Player fell off the screen!");
        Debug.Log("Falling off. Last platform: " + (lastPlatform != null ? lastPlatform.name : "null"));
        RespawnPlayerFall();
        };
       
       // Input movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpcount++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 1)
        {
            rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
            jumpcount = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Ground"))
    {
        Debug.Log($"Collision ENTER detected with: {collision.gameObject.name}");
        lastPlatform = collision.gameObject;
        Debug.Log($"Last platform updated to: {lastPlatform.name}");
        jumpcount = 0;
    }
    if (collision.gameObject.CompareTag("Enemy"))
    {
        Debug.Log("Player collided with enemy!");
        // Respawn the player
        RespawnPlayerCollideEnemy();
    }
}
private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        Debug.Log($"Collision EXIT detected with: {collision.gameObject.name}");
    }
}

/// ADD PLAYER DEATH LOGIC HERE


    private void RespawnPlayerFall()
{
    if (lastPlatform != null) // Ensure the lastPlatform is valid
    {
        // Calculate respawn position based on last platform
        Vector3 respawnPosition = lastPlatform.transform.position;
        respawnPosition.y += 2f; // Add Y offset to respawn slightly above the platform

        // Reposition the player
        transform.position = respawnPosition;

        // Reset velocity to avoid residual motion
        rb.linearVelocity = Vector2.zero;

        Debug.Log("Player respawned at last platform: " + lastPlatform.name);
    }
    else
    {
        Debug.LogWarning("No platform available for respawn.");
    }
}

    private void RespawnPlayerCollideEnemy()
    {
        if (lastPlatform != null) // Ensure the lastPlatform is valid
    {
        // Calculate respawn position based on last platform
        Vector3 respawnPosition = lastPlatform.transform.position;
        respawnPosition.y += 30f; // Add Y offset to respawn slightly above the platform
        respawnPosition.x += -25f; // Add X offset to respawn slightly to the left of last position
        // Reposition the player
        transform.position = respawnPosition;

        // Reset velocity to avoid residual motion
        rb.linearVelocity = Vector2.zero;

        Debug.Log("Player respawned at last platform: " + lastPlatform.name);
    }
    else
    {
        Debug.LogWarning("No platform available for respawn.");
    }
        
    }


}
