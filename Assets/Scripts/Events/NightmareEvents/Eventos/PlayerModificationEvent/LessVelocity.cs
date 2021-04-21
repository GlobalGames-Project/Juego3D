using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessVelocity : PlayerEvents
{
    public override void EventoAction()
    {
        player.GetComponent<ControllerFPS>().movemenet.changeBaseSpeed(10f);
        player.GetComponent<ControllerFPS>().movemenet.changeSprintingSPeed(20f);
    }

    public override void Init(GameObject player)
    {
        this.player = player;
        EventoAction();
    }
}
