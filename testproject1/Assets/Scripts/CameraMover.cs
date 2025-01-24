using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover Instance;
    private Camera mainCamera;
    public float panSpeed = 20f; // Speed for camera panning

    private Transform playerTransform; // Reference to the player's transform
    private Vector3 targetPosition;   // Current target position
    private bool shouldFollowPlayer = false; // Whether the camera should follow the player

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            mainCamera = Camera.main;

            // Initialize targetPosition with the camera's starting position
            targetPosition = mainCamera.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Automatically find the player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (shouldFollowPlayer && playerTransform != null)
        {
            // Continuously update the target position to follow the player
            targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f); // Add Z offset
        }

        // Smoothly move the camera to the target position
        mainCamera.transform.position = Vector3.MoveTowards(
            mainCamera.transform.position,
            targetPosition,
            panSpeed * Time.deltaTime
        );
    }

   public void MoveTo(Vector3 newTargetPosition)
{
    if (shouldFollowPlayer)
    {
        // If the camera is set to follow the player, set targetPosition dynamically in Update
        Debug.Log("Camera set to follow player.");
    }
    else
    {
        // Set a static target position
        targetPosition = newTargetPosition;
        Debug.Log($"Camera moving to static position: {targetPosition}");
    }
}
}
