﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noTilt : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().SetPositionAndRotation(GetComponent<Transform>().position, new Quaternion());
    }
}