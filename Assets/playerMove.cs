using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 40f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    
    private Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        float horizMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }

        Vector2 movement = new Vector2(horizMove, vertMove);
        rb2d.AddForce(movement * speed);
    }

    void Update()
    {

    } 

}
