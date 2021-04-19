using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchMain : MonoBehaviour
{
    public Camera BroCam;
    public Camera MomCam;
    public Camera MainCam;
    void Start()
    {
        BroCam.enabled = true;
        MainCam.enabled = false;
        MomCam.enabled = true;
    }

 
    private void OnTriggerEnter(Collider other)
    {
        BroCam.enabled = false;
        MainCam.enabled = true;
        MomCam.enabled = false;
    }
}
