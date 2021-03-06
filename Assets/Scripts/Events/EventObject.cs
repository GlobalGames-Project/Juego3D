﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EventObject
{
    private List<bool> activeEventos = new List<bool>();

    public EventObject() {
        for (int I = 0; I < (int)NightmareEventosEnum.EventosEnum.size; I++)
        {
            activeEventos.Add(false);
        }
    }

    public bool eventIsActive(int eventId)
    {
        return activeEventos[eventId];
    }

    public void setActiveEvento(int eventId)
    {
        activeEventos[eventId] = true;
    }
}
