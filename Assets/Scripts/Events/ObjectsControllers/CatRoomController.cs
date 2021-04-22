using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRoomController : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoAcariciarGato; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoGato; // id para eventos    
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
            }
        }
    }
}
