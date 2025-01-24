using UnityEngine;
using System.Collections;


public class CameraChildMover : MonoBehaviour
{
    public Transform player;

private void LateUpdate()
{
    if (transform.parent == null && player != null)
    {
        // Detached: Do nothing; camera stays where it is.
        return;
    }

    // Follow the player while attached
    transform.position = new Vector3(player.position.x, player.position.y, -10f);

    // Prevent rotation
    transform.rotation = Quaternion.identity;
}

public void FreezeCamera()
{
    Debug.Log("FreezeCamera called!"); // Confirm function execution
    transform.parent = null; // Detach the camera from the player
}

}
