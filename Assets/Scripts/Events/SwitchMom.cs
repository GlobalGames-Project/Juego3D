using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchMom : MonoBehaviour
{
    public Camera BroCam;
    public Camera MomCam;
    public Camera MainCam;

    void Start()
    {
        BroCam.enabled = false;
        MainCam.enabled = true;
        MomCam.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        BroCam.enabled = false;
        MainCam.enabled = false;
        MomCam.enabled = true;
    }
}
