using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{

    public int id; // id para los dialogos

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        EventGenerator.current.DialogueShow(id);
    }
}
