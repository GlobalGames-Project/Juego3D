using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextVisibility : MonoBehaviour
{

Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position); // Grab the distance from the camera
        if (viewPos.z < 10F) // How far away is it?
        {
            this.gameObject.SetActive(false);
        }
    }
}
