// Main camera mover script
// Uses SetTargetPosition to get a new target position and change shouldMove to true
// Calculates the distance between the current position and the target position
// Moves there at a speed set by panSpeed until it reaches the target position

using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover Instance;
    private Camera mainCamera;
    public float panSpeed = 20f; // Speed for camera panning
    public Vector3 targetPosition;
    private bool shouldMove = false; // Flag to move the camera

   private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            mainCamera = Camera.main;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        // Move the camera smoothly to the target position
        if (shouldMove)
        {
            Debug.Log($"Camera Position: {mainCamera.transform.position}, Target Position: {targetPosition}");
            mainCamera.transform.position = Vector3.MoveTowards(
                mainCamera.transform.position,
                targetPosition,
                panSpeed * Time.deltaTime
            );

            // Stop moving if the camera reaches the target position
           if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.1f)
            {
                Debug.Log("Camera reached target position.");

                shouldMove = false;
            }
        }
    }

    public void MoveTo(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
        shouldMove = true;
    }
}



