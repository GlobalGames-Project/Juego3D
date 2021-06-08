using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFloor : MonoBehaviour
{
    public Camera MainCam;
    public Camera InfCam;


    void Start()
    {
        MainCam.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        InfCam.enabled = true;
        MainCam.enabled = false;
    }
}