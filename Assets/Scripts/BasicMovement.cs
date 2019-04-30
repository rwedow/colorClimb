using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    Transform playerGraphics;
    public bool facingRight = false;

    // Update is called once per frame
    void Update()
    {
        //initializting the variables for different animation states
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //animator.SetBool("IsMovingLeft", Input.GetKeyDown(KeyCode.LeftArrow));
        //animator.SetBool("IsMovingRight", Input.GetKeyDown(KeyCode.RightArrow));
        //animator.SetBool("IsMoving", (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)));

        float horMove = Input.GetAxis("Horizontal");
        //float vertMove = Input.GetAxis("Vertical");

        if(horMove < 0) {
            if (!facingRight) {
                FlipHorizontal();
            }
            animator.SetBool("IsMoving", true);
        } else if (horMove > 0) {
            if (facingRight) {
                FlipHorizontal();
            }
            animator.SetBool("IsMoving", true);
        }  else {
            animator.SetBool("IsMoving", false);
        }

        Vector3 movement = new Vector3(horMove, 0.0f, 0.0f);
        transform.position = transform.position + movement * Time.deltaTime * 10;
    }

    void FlipHorizontal() {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
