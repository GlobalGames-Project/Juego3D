using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{

     int idDialogo = (int)EnumDialogosId.dialogoAbrirVentana ; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoMasVida; // id para eventos

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        EventGenerator.current.DialogueShow(idDialogo);
    }
}
