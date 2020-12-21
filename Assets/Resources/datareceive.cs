using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datareceive : MonoBehaviour
{
    public static datareceive instance;
    private List<es> ES = new List<es>();
    public Rigidbody rb;
    private int j = 0;
    public Vector3 firstPos;

    void Start()
    {
        instance = this;
        
        Application.targetFrameRate = 100;

        rb = GetComponent<Rigidbody>();

        TextAsset Acdata = Resources.Load<TextAsset>("Nara");

        string[] data = Acdata.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] col = data[i].Split(new char[] { ',' });

            es x = new es();

            float.TryParse(col[0], out x.ns);
            float.TryParse(col[1], out x.ew);
            float.TryParse(col[2], out x.ud);

            ES.Add(x);

        }

    }

   
    void FixedUpdate()
    {
        
        j++;
        //Debug.Log("round is = " + j);
    
        rb.AddForce(transform.forward * ES[j].ns, ForceMode.Acceleration);
        //Debug.Log(ES[j].ns); 
        rb.AddForce(transform.right * ES[j].ew, ForceMode.Acceleration);
        //Debug.Log(ES[j].ew);
        rb.AddForce(transform.up * ES[j].ud, ForceMode.Acceleration);
        //Debug.Log(ES[j].ud);
        firstPos = transform.position;
        
    }
}
