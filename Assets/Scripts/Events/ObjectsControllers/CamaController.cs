using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaController : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoCamaDormir; // id para los dialogos
    public bool isActive = true;
    public GameObject light;
    static bool talkWithMom=false;


    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if (Input.GetButton("Submit") && talkWithMom)
            {
                isActive = false;
                EventGenerator.current.DialogueShow(idDialogo);
                light.SetActive(isActive);
                TimeManager.tiempo = ((60*3)-2);
            }
        }


    }

    private void Update()
    {
        if (talkWithMom)
        {
            light.SetActive(true);
        }
    }

    public static void talkMom()
    {
        talkWithMom = true;
    }
}
