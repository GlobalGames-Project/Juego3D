﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cama : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoCamaDormir; // id para los dialogos
    bool isActive = true;
    public GameObject light;


    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if (Input.GetButton("Submit"))
            {
                isActive = false;
                EventGenerator.current.DialogueShow(idDialogo);
                light.SetActive(isActive);
                TimeManager.tiempo = 960f;
            }
        }
    }
}