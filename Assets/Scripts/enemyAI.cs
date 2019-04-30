//using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class enemyAI : MonoBehaviour
{
//floating
    public Transform target;
    public float updateRate = 2f;

    public float karlRange;
    public LayerMask whoIsRain;
    public int damage;

    private Seeker seeker;
    private Rigidbody2D rb;

    //storing ref to the calculated path
    public Path path;

    //AI's speed per sec
    public float speed = 300f;
    //way to control the way the force is applied to our rb/enemy
    public ForceMode2D fMode;

    //public but won't show up in inspector
    [HideInInspector] 
    public bool pathIsEnded = false;

    //max dist from AI to waypt for it to continue to next waypt
    public float nextWaypointDistance = 3;
    
    //waypt we're currently moving towards
    private int currWaypt;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //if no target's been assigned
        if(target == null)
        {
            Debug.LogError("No player found!");
            return;
        }
        
        //start a path from curr pos to target pos
        //when done creating this path, call on path complete
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());

      }//end Start

    IEnumerator UpdatePath ()
    {
        if(target == null)
        {
            //insert a player search here
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        // Debug.Log("starting path");

        //the more we wait the shorter the update rate time is
        yield return new WaitForSeconds(1f/updateRate);
        StartCoroutine(UpdatePath());

    }//end UpdatePath

    // Update is called once per frame
    void Update()
    {
        Collider2D[] playerDamage = Physics2D.OverlapCircleAll(transform.position, karlRange, whoIsRain);
        for (int i = 0; i < playerDamage.Length; i++)
        {
            playerDamage[i].GetComponent<Rain>().TakeDamage(damage);
        }
    }//end Update

    public void OnPathComplete(Path p)
    {
        //just checking if path is successful
        //if it is ok, set curr path to the path that it found
        // Debug.Log("We got a path. Did it have an error?" + p.error);
        if (!p.error)
        {
            path = p;
            //set curr pos at the beginning of the path
            currWaypt = 0;
        }
    }//end OnPathComplete

    void FixedUpdate()
    {
        //has fixed update rate that is good for physics calculations

        if (target == null)
        {
            Debug.LogError("No player found!");
            return;
        }

        //always look at player

        if (path == null)
        {
            return;
        }

        //checks if curr waypt is >= total amt of waypts in array of waypts        
        if(currWaypt >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        //find direction to next waypt
        Vector3 dir = (path.vectorPath[currWaypt] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //move enemy
        rb.AddForce(dir, fMode);

        float distance = Vector3.Distance(transform.position, path.vectorPath[currWaypt]);

        if (distance < nextWaypointDistance)
        {
            currWaypt++;
            return;
        }
        
    }//end FixedUpdate

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, karlRange);
    }


}//end class
