using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEventController : MonoBehaviour {

    public GameObject player;
    private EventObject eventObject;

    private void Start()
    {
        eventObject = BinariSave.Load();

        for (int i = 0; i < (int) NightmareEventosEnum.EventosEnum.size; i++) {
            Debug.Log(eventObject.eventIsActive(i));
            if (eventObject.eventIsActive(i))
            {
                PlayerEvents eventObject = NightmareEventosEnum.eventos[i];
                eventObject.Init(player);
                eventObject.EventoAction();
            }
        }

    }
}
