using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{

    public int health;
    public int points;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
