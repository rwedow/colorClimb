using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilCloud : MonoBehaviour
{
    public float speed;
    public int leftBound;
    public int rightBound;
    public bool moveRight;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound) {
            moveRight = true;
        } else if (transform.position.x > rightBound) {
            moveRight = false;
        }

        if(moveRight) {
            Vector3 newVec = transform.position;
            newVec.x += speed;
            transform.position = newVec;
        } else {
            Vector3 newVec = transform.position;
            newVec.x -= speed;
            transform.position = newVec;
        }
    }
}
