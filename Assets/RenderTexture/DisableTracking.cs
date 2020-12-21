using UnityEngine;
using System.Collections;

public class DisableTracking : MonoBehaviour {
    private Camera cam;
    private Vector3 startPos;

    void Start () {
        cam = GetComponentInChildren<Camera>();
        startPos = transform.localPosition;
        
    }
	
    void Update () {
        var transform1 = cam.transform;
        transform.localPosition = startPos - transform1.localPosition;
        transform.localRotation = Quaternion.Inverse(transform1.localRotation);
        Debug.Log("Position : " + transform1.localPosition);
    }
}