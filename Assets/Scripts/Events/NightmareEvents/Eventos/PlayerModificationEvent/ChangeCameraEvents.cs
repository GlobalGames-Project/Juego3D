using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeCameraEvents : NightmareEvento
{

    public PostProcessProfile camera;
    public GameObject cameraObject;

    public override void EventoAction()
    {
        PostProcessProfile[] cameraList = cameraObject.GetComponent<CameraListSettings>().camera.profiles;
        int i = cameraList.Length;
        Debug.Log(i);
        int range = Random.Range(0, i);
        Debug.Log(range);
        camera = cameraList[range];
        if (camera != null) {
            cameraObject.GetComponent<PostProcessVolume>().profile = camera;
        }
        Debug.Log(camera.name);
    }

    public void init(GameObject cameraObject) {
        this.cameraObject = cameraObject;
    }
}
