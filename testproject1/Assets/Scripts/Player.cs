using UnityEngine;

public class Player : MonoBehaviour
{
   // Set the speed variable
   public float speed = 5.0f;
   public float jumpForce = 10.0f;
   public float doubleJumpForce = 60.0f;
   private int jumpcount = 0;

   private Rigidbody2D rb;
   private bool isGrounded = false;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpcount++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 1)
        {
            rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
            jumpcount++;
        }

        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpcount = 0;
        }
    }
}
