using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollower : MonoBehaviour
{
    public GameObject Target = null;
    public GameObject t = null;
    public float speed = 1.5f;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        t = GameObject.FindGameObjectWithTag("Target");
    }

    private void FixedUpdate()
    {
        this.transform.LookAt(Target.transform);
        float carmove = Mathf.Abs(Vector3.Distance(this.transform.position, t.transform.position) * speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position, t.transform.position, carmove * Time.deltaTime);
    }
}
