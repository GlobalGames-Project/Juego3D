using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJumpForce : PlayerEvents
{
    public override void EventoAction()
    {
        player.GetComponent<ControllerFPS>().movemenet.jumpForce += 750;
    }

    public override void Init(GameObject player)
    {
        this.player = player;
        EventoAction();
    }
}
