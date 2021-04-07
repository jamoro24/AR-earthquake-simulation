using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitTest : MonoBehaviour
{
    Texture aTexture;
    public RenderTexture rTex;
    public Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void OnPreRender()
    {
        cam.targetTexture = rTex;
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.Blit(aTexture, rTex);
    }
}
