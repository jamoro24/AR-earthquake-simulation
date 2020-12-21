using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HeadMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject head;
    public GameObject floor;
    public GameObject refFloor;
    public GameObject refHead;
    public int delay = 100;
    public int dist = 1;
    public float multi = 0.01f;
    public float normalize = 1.00f;

    private List<Vector3> posList = new List<Vector3>();
    private List<Vector3> posList2 = new List<Vector3>();
    
    void Start()
    {
        
        var tmp = floor.transform.position;
        var tmp2 = head.transform.position;
        
        for (int i = 0; i < 100; i++)
        {
            posList.Add(tmp);
            posList2.Add(tmp2);
        }
    }
    void FixedUpdate()
    {
        var tmp = floor.transform.position;
        var tmp2 = head.transform.position;
        var tmp3 = refFloor.transform.position;
        var tmp4 = refHead.transform.position;
        posList.Add(tmp);
        posList2.Add(tmp2);
        var p1 = posList2[posList2.Count - delay];
        Debug.Log("P1 = " + p1);
        //var p2 = posList2[posList2.Count - (delay - dist)];
        var x1 = posList[posList.Count - delay];
        Debug.Log("x1 = " + x1);
        var x2 = posList[posList.Count - (delay - dist)];
        Debug.Log("x2 = " + x2);
        
        head.transform.position = new Vector3((p1.x * x2.x)/x1.x, (p1.y * x2.y)/x1.y,(p1.z * x2.z)/x1.z);// + new Vector3(posDist.x * multi, posDist.y * multi, posDist.z * multi)) / normalize;
    }

    public void printList(List<Vector3> bobo)
    {
        foreach (var i in bobo)
        {
            Debug.Log(i);
        }
    }




}
