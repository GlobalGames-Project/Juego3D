using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineCat : MonoBehaviour
{
    public enum State { StateFollow, StateTurn }
    private State currentState;
    public NavMeshAgent cat;
    public Transform player;
    public GameObject light;
    int idDialogo = (int)EnumDialogosId.dialogoAcariciarGato; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoVaMasLento; // id para eventos
    public bool isActive = true;


    void Start()
    {
        CheckState();
        currentState = State.StateTurn;
    }

    private void CheckState()
    {
        switch (currentState)
        {
            case State.StateFollow:
                Follow();
                break;
            case State.StateTurn:
                Turn();
                break;
        }
    }

    private void Turn()
    {
        void OnTriggerStay(Collider other)
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
        if (isActive = false)
        {
            currentState = State.StateFollow;
        }
    }

    private void Follow()
    {
        cat.SetDestination(player.position);
        currentState = State.StateTurn;
    }
}