using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeCameraEvents : NightmareEvento
{

    public PostProcessProfile camera;
    public GameObject player;

    public override void EventoAction()
    {
        player.GetComponent<PostProcessVolume>().profile = camera;
    }

    public void init(GameObject player, PostProcessProfile camera) {
        this.player = player;
        this.camera = camera;
    }
}
