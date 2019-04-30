using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{

    public int health;
    public int points;
    public Animator anim;
    public int[] paintColors;
    // 0 = red 1 = yellow 2 = blue

    // Start is called before the first frame update
    void Start()
    {
        paintColors = new int[4];
    }

    // Update is called once per frame
    void Update() {
    }

    public void TakeDamage(int damage) {
        if (!anim.GetBool("Umbrella")) {
            Debug.Log("OUCH");
            health -= damage;
        }
    }
    /*
    public void PickUpCan(int canSize)
    {
        Debug.Log("Got Paint (Size: " + canSize + ")");
        points += canSize;
    }
    */
    public void PickUpCan(int canColor)
    {
        // 0 = color, 1 = num points
        //Debug.Log(pickUp[0] + " " + pickUp[1]);
        //paintColors[pickUp[0]] = pickUp[1];
        paintColors[canColor] += 3;
    }
}
