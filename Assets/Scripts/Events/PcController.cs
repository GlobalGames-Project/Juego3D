using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour
{
    public int id; // id para los dialogos
                 

    private void OnTriggerEnter(Collider other)
    {
        EventGenerator.current.DialogueShow(id);
    }
}
