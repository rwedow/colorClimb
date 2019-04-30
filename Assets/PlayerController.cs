using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float maxSpeed;
    public SpriteRenderer sr;
    public double drag;

    private Rigidbody2D rb;
    private Vector2 jump = new Vector2(0.0f, 1.0f);
    bool ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.color = Color.white;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement * speed);

        if (movement.magnitude < 0.1)
        {
            rb.velocity = new Vector2((float)(rb.velocity.x / drag), rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            if (rb.velocity.x > maxSpeed)
            {
                rb.velocity.Set(maxSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x < -maxSpeed)
            {
                rb.velocity.Set(-maxSpeed, rb.velocity.y);
            }
        }
    }
}