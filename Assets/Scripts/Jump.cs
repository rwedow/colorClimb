using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Animator animator;
    public float jumpVelocity = 10;

    public LayerMask groundLayer;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            if (IsGrounded()) {
                animator.SetBool("IsJumping", true);
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            }
        }
        if (IsGrounded()) {
            animator.SetBool("IsJumping", false);
        } else {
            animator.SetBool("IsJumping", true);
        }
    }
}
