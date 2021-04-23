using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchBro : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        BroCam.enabled = true;
        MainCam.enabled = false;
        MomCam.enabled = false;
    }
}