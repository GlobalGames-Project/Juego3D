using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGenerator : MonoBehaviour
{
    public GameObject[] eventosPrefabs;
    public static EventGenerator current;

    private void Awake()
    {
        current = this;
    }

    // Evento Madre
    public event Action onMamaTimeEnter;
    
    public void MamaTimeEnter()
    {
        if(onMamaTimeEnter!= null)
        {
            onMamaTimeEnter();
        }
    }

    //Evento activo cuando sale el dialogo
    public event Action onDialogueGoing;
    public void DialogueGoing()
    {
        if (onDialogueGoing != null)
        {
            onDialogueGoing();
        }
    }

    // Evento que se activa cuando se acaba el dialogo
    public event Action onDialogueFinish;
    public void DialogueFinish()
    {
        if (onDialogueFinish != null)
        {
            onDialogueFinish();
        }
    }


    //Evento de mostrar dialogo
    public event Action<int> onDialogueShow;
    public void DialogueShow(int id)
    {
        if (onDialogueShow != null)
        {
            onDialogueShow(id);
        }
    }


    


    // Start is called before the first frame update
    void Start()
    {
        
        EventGenerator.current.onDialogueGoing += eliminar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void eliminar()
    {
        
    }


}
