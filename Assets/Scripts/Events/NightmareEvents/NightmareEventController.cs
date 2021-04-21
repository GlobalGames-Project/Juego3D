using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEventController : MonoBehaviour {

    private GameObject player;
    private EventObject eventObject;

    private void Start()
    {
        eventObject = BinariSave.Load();



    }

}
