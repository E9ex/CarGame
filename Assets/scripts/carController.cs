using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] private float CarSpeed;
    [SerializeField] private float maxspeed;
    [SerializeField] private float steerAngle;
    private float DragAmount = 0.99f;
    private Vector3 vecmove;

    private void Update()
    {
        vecmove += transform.forward * CarSpeed * Time.deltaTime;
        transform.position += vecmove * Time.deltaTime;
    
        transform.Rotate(Vector3.up*Input.GetAxis("Horizontal")*steerAngle*Time.deltaTime*vecmove.magnitude);
        vecmove *= DragAmount;
        vecmove = Vector3.ClampMagnitude(vecmove, maxspeed);
    }
}
