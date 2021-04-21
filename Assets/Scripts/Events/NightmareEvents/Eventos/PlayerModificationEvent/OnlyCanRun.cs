using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyCanRun : PlayerEvents
{
    public override void EventoAction()
    {
        player.GetComponent<ControllerFPS>().movemenet.changeBaseSpeed(40f);
    }

    public override void Init(GameObject player)
    {
        this.player = player;
        EventoAction();
    }
}
