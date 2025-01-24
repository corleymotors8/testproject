using UnityEngine;

public class TriggerCameraMove : MonoBehaviour
{
    public bool shouldFollowPlayer = false;
    private Transform platformTransform; // Reference to the platform's Transform

   private void Awake()
{
    Debug.Log($"Awake called on {gameObject.name}, Script Enabled: {enabled}");
}
   
   private void Start()
    {
   Debug.Log($"TriggerCameraMove attached to: {gameObject.name}, shouldFollowPlayer: {shouldFollowPlayer}");
   platformTransform = transform; // Automatically assign the current platform's Transform
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log($"shouldFollowPlayer for this platform: {shouldFollowPlayer}");

        if (collision.gameObject.CompareTag("Player") && shouldFollowPlayer == false)
        {
            Vector3 targetPosition = platformTransform.position + new Vector3(25f, -5f, -10f); // Offset for bottom-left positioning
            CameraMover.Instance.MoveTo(targetPosition); // Call the CameraMover script to move the camera
            Debug.Log($"Triggering MoveTo with target: {targetPosition}");
      
        }   
        if (collision.gameObject.CompareTag("Player") && shouldFollowPlayer == true)
        {
               
            Debug.Log("Triggering MoveTo to follow the player.");
            // Reference the player's position from the collision
            Transform playerTransform = collision.gameObject.transform;

            // Use the player's position for the camera target, adding an optional offset
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f);
                
            // Move the camera
            CameraMover.Instance.MoveTo(targetPosition); 
        }
    }
}
