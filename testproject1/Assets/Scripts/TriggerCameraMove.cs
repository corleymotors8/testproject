using UnityEngine;

public class TriggerCameraMove : MonoBehaviour
{
    public Vector3 targetPosition; // The desired camera position when triggered

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraMover.Instance.MoveTo(targetPosition); // Call the CameraMover script to move the camera
        }
    }
}
