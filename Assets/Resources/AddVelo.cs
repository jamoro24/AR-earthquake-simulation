using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVelo : MonoBehaviour
{
    private List<es> ES = new List<es>();
    private int j = 0;

    void Start()
    {
        Application.targetFrameRate = 100;

        TextAsset velocity = Resources.Load<TextAsset>("NaraVelo");

        string[] data = velocity.text.Split(new char[] {'\n'});

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] col = data[i].Split(new char[] {','});

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
        Debug.Log("round is = " + j);

        transform.Translate(transform.forward * ES[j].ns * Time.deltaTime);
        transform.Translate(transform.right * ES[j].ew * Time.deltaTime);
        transform.Translate(transform.up * ES[j].ud * Time.deltaTime);
    }

}