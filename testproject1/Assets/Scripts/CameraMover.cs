using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float panSpeed = 20f; // Speed for camera panning
    public Vector3 targetPosition;
    private bool shouldMove = false; // Flag to move the camera

    void Update()
    {
        if (shouldMove)
        {
            // Calculate the distance to move
            Vector3 moveDirection = targetPosition - transform.position;
            float distance = panSpeed * Time.deltaTime;

            // Move the camera towards the target position
            transform.position += moveDirection.normalized * distance;

            // Stop moving if the camera reaches the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                shouldMove = false;
            }
        }
    }
    public void SetTargetPosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
        shouldMove = true; // Enable movement

    }


}
