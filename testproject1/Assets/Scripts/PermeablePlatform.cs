using UnityEngine;

public class Platform3Permeable : MonoBehaviour
{
    public int maxHits = 3;
    private int hitCount = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
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
        ChangeColor();

        if (hitCount >= maxHits)
        {
            Destroy(gameObject);
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
