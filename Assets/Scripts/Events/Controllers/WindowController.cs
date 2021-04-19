using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{

     int idDialogo = (int)EnumDialogosId.dialogoAbrirVentana ; // id para los dialogos
    int idEvent = (int)EnumEventosId.eventoAbrirVentana ;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        EventGenerator.current.DialogueShow(idDialogo);
    }
}
