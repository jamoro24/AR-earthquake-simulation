using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Transform resetPos;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.position = resetPos.position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f,0.01f,0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f,-0.01f,0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.01f,0f,0f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.01f,0f,0f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position += new Vector3(0f,0f,0.01f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position += new Vector3(0f,0f,-0.01f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f,0.01f,0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f,-0.01f,0f);
        }
    }
}
