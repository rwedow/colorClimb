using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudStorm : MonoBehaviour
{
    public bool cloudEnter = true;
    public Transform moveCloud;
    float interval = 4;

    //private bool isRaining = false;
    //bool startRaining = GameObject.GetComponent<Rain>().startRaining;

    // Update is called once per frame
    void Update() {
        if (cloudEnter) {
            if (transform.position.x < 0)
            {
                Vector3 newVec = transform.position;
                newVec.x += 1;
                transform.position = newVec;
            } else if (transform.position.x > -1) {
                if (interval > 0) {
                    interval -= Time.deltaTime;
                } else {
                    interval = 5;
                    cloudEnter = false;
                }
            }
        } else {
            if (transform.position.x > -100)
            {
                Vector3 newVec = transform.position;
                newVec.x -= 1;
                transform.position = newVec;
            }
        }
    }
}
