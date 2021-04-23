using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaHermanoController : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoLlorarHermano; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoCaenGotas; // id para eventos    
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
