
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public int health;
    public float speed;
    public bool movingRight = true;
    private bool turnedAround = false;
    public Transform groundDetection;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject); //change later
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ray = Physics2D.Raycast(groundDetection.position, Vector2.down, 1000f);

        //check if hit - print debug log statement
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down)))
        {
            //just a test
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
            //Debug.Log("Did Hit");
        }
        //if ray has not collided with anything, time to turn around
        if (ray.collider == false) {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                turnedAround = false;
                //Debug.Log("***************************************\n\n\n\n");
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                turnedAround = false;
            }
        }

        if(movingRight) {
            if(!turnedAround) {
                FlipHorizontal();
            }
        } else {
            if(!turnedAround) {
                FlipHorizontal();
            }
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("damage TAKEN!");
    }

    void FlipHorizontal () {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        turnedAround = true;
    }
}
