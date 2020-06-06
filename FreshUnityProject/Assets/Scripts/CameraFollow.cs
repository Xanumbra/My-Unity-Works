﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target Object to be followed
    public Transform target;
    
    public float smoothSpeed = 0.125f;
    
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(target.position, desiredPosition,smoothSpeed * Time.deltaTime);
        transform.position = target.position + offset;

        transform.LookAt(target);
    }
}
