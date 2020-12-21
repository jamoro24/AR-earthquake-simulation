using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDist : MonoBehaviour
{
    // Start is called before the first frame update
    public float dist;
    private Camera _leftCamera;
    private Camera _rightCamera;

    private void Start()
    {
        _leftCamera = GameObject.Find("LeftEyeCamera").GetComponent<Camera>();
        _rightCamera = GameObject.Find("RightEyeCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _leftCamera.transform.position = transform.position + new Vector3(dist,0,0);
        _rightCamera.transform.position = transform.position + new Vector3( -dist,0,0);
    }
}
