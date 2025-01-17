using UnityEngine;


public class Platform3Permeable : MonoBehaviour


{

    public AudioClip crunchSound;
    public AudioClip breakSound;
    private AudioSource audioSource;
    public GameObject ExplodeEffect;
    public int maxHits = 3;
    private int hitCount = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Platform hit by Player!"); // Debug message for collision detection
        OnHit();
        
    }

    private void OnHit()
    {
        hitCount++;

        if (audioSource != null)
        {
            if (hitCount == 1)
            {
                audioSource.PlayOneShot(crunchSound); // First hit: Play crunch sound
            }
            else if (hitCount == 2)
            {
                audioSource.PlayOneShot(crunchSound); // Second hit: Play crunch sound
            }
            else if (hitCount == 3)
            {
                audioSource.PlayOneShot(breakSound); // Third hit: Play break sound
            }
        }

        ChangeColor();

        if (hitCount >= maxHits)
        {
            Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, Mathf.Min(breakSound.length, 0.2f)); // Destroy the game object after the break sound has finished playing
        }
    }

    private void ChangeColor()
    {
        if (spriteRenderer != null)
        {
            if (hitCount == 1)
            {
                spriteRenderer.color = Color.red; // First hit: Change to red
            }
            else if (hitCount == 2)
            {
                spriteRenderer.color = Color.blue; // Second hit: Change to blue
            }
        }
    }
}
