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
                float previousClipTime = centralAudioSource.time;

                // Debug: Log previous clip info
                Debug.Log($"Previous Clip: {centralAudioSource.clip.name}, Time: {previousClipTime}, Length: {centralAudioSource.clip.length}");

                // Set the new clip
                centralAudioSource.clip = platformMusic;

                // Clamp the starting position of the new clip to ensure it's valid
                float nextClipTime = Mathf.Clamp(previousClipTime, 0, platformMusic.length);

                // Debug: Log next clip info
                Debug.Log($"Next Clip: {platformMusic.name}, Starting Time: {nextClipTime}, Length: {platformMusic.length}");

                // Apply the time and play the new clip
                centralAudioSource.time = nextClipTime;
                centralAudioSource.Play();

                Debug.Log("Music changed smoothly to: " + platformMusic.name);
                hasPlayed = true; // Mark as played
            }
        }
    }
}