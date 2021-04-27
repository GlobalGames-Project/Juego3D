using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeCameraEvents : PlayerEvents
{

    public PostProcessProfile[] camera;
    public GameObject player;

    public override void EventoAction()
    {
        camera = player.transform.GetChild(1).GetComponent<CameraList>().cameras.profiles;

        int random = Random.Range(0, camera.Length);

        player.transform.GetChild(1).GetComponent<PostProcessVolume>().profile = camera[random];
    }

    public override void Init(GameObject player) {
        this.player = player;
    }
}
