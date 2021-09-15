using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HeadMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject virtualCam;
    public GameObject renderText;
    public GameObject actualCam;
    public GameObject refObject;
    //public GameObject Floor;
    //public GameObject OriginPoint;
    
    public int delay = 1;
    public int dist = 1;
    //public float G = 100;
    
   //private float dragFreq = 1.0f;
    //private float moveSpeed = 0.5f;
    //private Vector3 OriginPos;
    
    private List<Vector3> posList = new List<Vector3>();
    //private List<Vector3> posList2 = new List<Vector3>();

    private Rigidbody rb;
    
    void Start()
    {
        rb = renderText.GetComponent<Rigidbody>();

        Transform refObjectPos = refObject.transform;
        
        var tmp = refObjectPos.position;
        //var tmp2 = Floor.transform.position;
        
        for (int i = 0; i < 100; i++)
        {
            posList.Add(tmp);
            //posList2.Add(tmp2);
        }
    }
    void FixedUpdate()
    {
        //OriginPos = OriginPoint.transform.position;
        Transform virtualCamPos = virtualCam.transform;
        Transform renderTextPos = renderText.transform;
        Transform actualCamPos = actualCam.transform;
        Transform refObjectPos = refObject.transform;
        var threshold = Vector3.Distance(actualCamPos.position, refObjectPos.position) /
                        Vector3.Distance(virtualCamPos.position, renderTextPos.position);
        var thresholdH = 1;
        //Debug.Log(threshold);
        renderText.transform.position = renderTextPos.position + ((posList[posList.Count-delay] - 
                                                                   posList[posList.Count-delay-dist])/threshold);
        posList.Add(refObjectPos.position);
        //rb.velocity = G * Time.deltaTime * (OriginPos - transform.position);
    }
}