using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CopyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject original;
    public GameObject copy;
   
    private List<Vector3> posList = new List<Vector3>();

    private void Start()
    {
        var tmp = original.transform.position;
        for (int i = 0; i < 100; i++)
        {
            posList.Add(tmp);
        }
    }

    void FixedUpdate()
    {
        var tmp = original.transform.position;
        posList.Add(tmp);
        var pos3 = posList[posList.Count - 1];
        var pos4 = posList[posList.Count - 2];
        var posDist = pos4 - pos3;
        copy.transform.position = copy.transform.position + posDist;
    }
}

