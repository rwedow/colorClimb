using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.V)) {
            anim.SetBool("Umbrella", true);
        } else {
            anim.SetBool("Umbrella", false);
        }
    }
}
