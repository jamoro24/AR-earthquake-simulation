using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTest : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 IniPos;
    private float G = 100;
    private void Start()
    {
        IniPos = transform.position; //new Vector3(0,0,0);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        /*Vector3 dir = transform.position - IniPos;
        float dist = dir.magnitude;

        if (dist == 0)
        {
            return;
        }

        float forceMag = G * 10 / Mathf.Pow(dist, 2);
        Vector3 force = dir.normalized * forceMag;
        rb.AddForce (force);*/
        
        Vector3 dir = transform.position - IniPos;
        float dist = dir.magnitude;

        Vector3 force = dir.normalized * 2;
        rb.velocity = G * Time.deltaTime * (IniPos - transform.position);
    }
}
