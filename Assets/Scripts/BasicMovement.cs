using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement  : MonoBehaviour
{
    public Animator animator;

    public float speed = 40f;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    //void FixedUpdate()
    //{
    //    float horizMove = Input.GetAxis("Horizontal");
    //    float vertMove = Input.GetAxis("Vertical");

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        rb2d.AddForce(jump * jumpForce, ForceMode2D.Impulse);
    //    }

    //    Vector2 movement = new Vector2(horizMove, vertMove);
    //    rb2d.AddForce(movement * speed);
    //}


    // Update is called once per frame
    void Update()
    {
        //initializting the variables for different animation states
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetBool("IsMovingLeft", Input.GetKeyDown(KeyCode.LeftArrow));
        animator.SetBool("IsMovingRight", Input.GetKeyDown(KeyCode.RightArrow));
        animator.SetBool("IsMoving", (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)));

        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        //handles jumping!
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }

        Vector3 movement = new Vector3(horMove, vertMove, 0.0f);
        rb2d.AddForce(movement * speed);

        transform.position = transform.position + movement * Time.deltaTime * 10;

        //moving side to side
        //Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        //transform.position = transform.position + horizontal * Time.deltaTime * 10;





    }
}
