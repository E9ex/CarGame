using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollower : MonoBehaviour
{
    public Transform player;
    public Vector3 ofst;
    void Start()
    {
        ofst = transform.position - player.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + ofst, Time.deltaTime*5);
    }
}
