using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public datareceive SimuStart;
    
    void Start()
    {
        SimuStart = GetComponent<datareceive>();
        SimuStart.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SimuStart.enabled = true;
        }
    }
}
