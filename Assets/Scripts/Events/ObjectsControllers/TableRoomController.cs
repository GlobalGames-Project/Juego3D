﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRoomController : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoMesaHabitacion; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoNoPuedeCaminar; // id para eventos    
    public bool isActive = true;
    public GameObject light;


    private void Start()
    {
        light.SetActive(isActive);
    }
    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if (Input.GetButton("Submit"))
            {
                isActive = false;
                EventGenerator.current.DialogueShow(idDialogo);
                DiaGameManager.eventObject.setActiveEvento(idEvent);
                light.SetActive(isActive);
            }
        }
    }
}
