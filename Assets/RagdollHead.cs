using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollHead : MonoBehaviour
{
    public GameObject Head;
    private Vector3 OriginHeadPos;
    private Vector3 CurrentHeadPos;
    private Vector3 OriginRTPos;
    private Vector3 offset;
    void Start()
    {
        OriginHeadPos = Head.transform.position;
        
    }

    void FixedUpdate()
    {
        CurrentHeadPos = Head.transform.position;
        OriginRTPos = this.transform.position;
        offset = CurrentHeadPos - OriginHeadPos;
        //Debug.Log("offset is = " + offset);
        transform.position = OriginRTPos + offset;
    }
}
