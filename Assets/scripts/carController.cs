using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] private float CarSpeed;
    [SerializeField] private float maxspeed;
    [SerializeField] private float steerAngle;
    [SerializeField] private float traction;
    public Transform lw, rw;
    
    private float DragAmount = 0.99f;
    private Vector3 vecmove;
    private Vector3 vecrot;

    private void Update()
    {
        vecmove += transform.forward * CarSpeed * Time.deltaTime;
        transform.position += vecmove * Time.deltaTime;


        vecrot += new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate(Vector3.up*Input.GetAxis("Horizontal")*steerAngle*Time.deltaTime*vecmove.magnitude);
        
        
        vecmove *= DragAmount;
        vecmove = Vector3.ClampMagnitude(vecmove, maxspeed);
        vecmove=Vector3.Lerp(vecmove.normalized,transform.forward,traction*Time.deltaTime)*vecmove.magnitude;// if x,y,z=2,4,6 normalized version== 0.2,0.4,0.6 drift için 
        //magnitude= büyüklük
        
        vecrot=Vector3.ClampMagnitude(vecrot,steerAngle);
        lw.localRotation=Quaternion.Euler(vecrot);//vectore göre açı vermemize sağlıyor.
        rw.localRotation=Quaternion.Euler(vecrot);
    }
}
