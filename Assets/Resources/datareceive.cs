using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class datareceive : MonoBehaviour
{
    private List<es> ES = new List<es>();
    public Rigidbody rb;
    private int j = 0;
    public GameObject sound1;
    public GameObject sound2;
    public GameObject WarningPos;
    public GameObject warning;
    public ZEDManager zedManager;

    void Start()
    {
        File.WriteAllText(DateTime.Now.ToString("yyyy-MM-dd-T-HH-mm-ss.txt"), "");
        zedManager = FindObjectOfType<ZEDManager> ();
        sound1.SetActive(true);
        StartCoroutine(WarningDisplay());
        StartCoroutine(Wait(24f));

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
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Waiting");
        sound2.SetActive(true);
        
    }
    
    Text msg;
    public int degree = 270;
    /// <summary>
    /// Positions, configures and displays the warning text at the start of the game.
    /// Sets canspawn (which defaults to false) to true once finished, so that drones only spawn afterward. 
    /// </summary>-
    /// <returns></returns>
    IEnumerator WarningDisplay() 
    {
        GameObject warningMsg = Instantiate(warning); //Spawn the message prefab, which doesn't have the correct text yet. 

        if (zedManager != null)
        {
            warningMsg.transform.position = WarningPos.transform.position + (Vector3.forward * 2) + (Vector3.up * 0.75f);//zedManager.OriginPosition + zedManager.OriginRotation * (Vector3.forward * 2);
            Quaternion newRot = Quaternion.LookRotation (zedManager.OriginPosition - warningMsg.transform.position, Vector3.up);
            warningMsg.transform.eulerAngles = new Vector3 (0, newRot.eulerAngles.y + degree, 0);
        }

        Text msg = warningMsg.GetComponentInChildren<Text>(); //Find the text in the prefab. 

        yield return new WaitForSeconds(1f);

        //Add the letters to the message one at a time for effect. 
        int i = 0;
        string oldText = "EARTHQUAKE IMMINENT!";
        string newText = "";
        while (i < oldText.Length) 
        {
            newText += oldText[i++];
            yield return new WaitForSeconds(0.15F); 
            msg.text = newText;
        }

        yield return new WaitForSeconds(3f); //Let the user read it for a few seconds. 

        //Change the warning message by clearing it and adding letters one at a time like before. 
        i = 0;
        oldText = "BRACE YOURSELF!";
        newText = "";
        while (i < oldText.Length)
        {
            newText += oldText[i++];
            yield return new WaitForSeconds(0.1F);
            msg.text = newText;
        }

        yield return new WaitForSeconds(3f);//Let the user read it for a few seconds. 

        Destroy(warningMsg);
        
    }
}

