
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (ray.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                Debug.Log("***************************************\n\n\n\n");
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
