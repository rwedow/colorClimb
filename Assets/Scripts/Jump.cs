using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity = 10;

    public LayerMask groundLayer;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 3.64f;

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
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            }
        }
    }
}
