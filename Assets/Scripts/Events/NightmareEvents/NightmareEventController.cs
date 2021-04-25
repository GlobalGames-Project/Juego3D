using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEventController : MonoBehaviour {

    private GameObject player;
    private EventObject eventObject;

    private void Start()
    {
        eventObject = BinariSave.Load();
        PlayerEvents playerEvents = null;

        for (int i = 0; i < (int) NightmareEventosEnum.EventosEnum.size; i++) {
            if (eventObject.eventIsActive(i)) {
                if (i != 2) { playerEvents.Init(player); }
                else { playerEvents.Init(player.transform.GetChild(1).gameObject); }
                playerEvents.EventoAction();
            }
        }
    }

}
