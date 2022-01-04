using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{

    public Camera cam = null;

    // Start is called before the first frame update
    void Start()
    {
        if(cam == null) {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Transform>().LookAt(cam.transform);
    }
}
