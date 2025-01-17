using UnityEngine;

public class PlatformMusicHandler : MonoBehaviour
{
    public AudioClip platformMusic; // Assign this in the Inspector for each platform
    public AudioSource centralAudioSource; // Reference to the "Music" object AudioSource
    private bool hasPlayed = false; // Track if music has already played


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasPlayed)
        {
            if (centralAudioSource != null && platformMusic != null)
            {
                 // Get the current time position within the current clip
                float currentTime = centralAudioSource.time;

                // Set the new clip
                centralAudioSource.clip = platformMusic;

                // Set the starting position of the new clip to match the last clip's position
                centralAudioSource.time = currentTime;

                // Play the new clip from the calculated position
                centralAudioSource.Play();

                Debug.Log("Music changed to: " + platformMusic.name); // Debug to confirm
                hasPlayed = true; // Mark as played
            }
        }
    }
}
