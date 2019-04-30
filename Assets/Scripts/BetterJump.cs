using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public Animator animator;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        float acceleration = rb.velocity.y;
        //float acceleration = Input.GetAxis("Vertical");
        animator.SetFloat("LastVel", acceleration);

        if (acceleration > 0) {
            animator.SetBool("UpJump", true);
        } else if (acceleration < 0) {
            animator.SetBool("UpJump", false);
        }

    }
}
