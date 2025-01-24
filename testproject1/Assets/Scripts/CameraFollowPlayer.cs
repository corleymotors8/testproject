// // This script is used to make the camera follow the player when the player collides with the platform.
// // Takes the current camera position and the player position
// // Uses lerp to pass a continuously updated variable to target position 
// // This allows camera to smoothly move toward target position (centered on player)

// using UnityEngine;

// public class Platform6CameraFollow : MonoBehaviour
// {
//     public CameraMover cameraMover; // Reference to the CameraMover script; 
//     public Transform player; // Reference to the player's transform

//     private bool shouldFollowPlayer = false; // Flag to enable player-following

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             shouldFollowPlayer = true; // Enable player-following
//             Debug.Log("Camera now following player.");
//         }
//     }

//    private void Update()
//     {
//         if (shouldFollowPlayer && player != null)
//         {
//             // Smoothly move the camera toward the player's position using interpolation
//             Vector3 currentCameraPosition = cameraMover.transform.position;
//             Vector3 targetCameraPosition = new Vector3(player.position.x, player.position.y, cameraMover.transform.position.z);

//             // Use Vector3.Lerp for smooth movement
//             Vector3 smoothedPosition = Vector3.Lerp(currentCameraPosition, targetCameraPosition, Time.deltaTime * cameraMover.panSpeed);

//             CameraMover.Instance.MoveTo(newTargetPosition);
//         }
//     }
// }