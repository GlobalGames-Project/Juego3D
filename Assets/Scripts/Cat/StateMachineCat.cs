using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineCat : MonoBehaviour
{
    public enum State { StateFollow, StateTurn}
    private State currentState;
    public NavMeshAgent cat;
    public Transform player;
    public GameObject light;
    int idDialogo = (int)EnumDialogosId.dialogoAcariciarGato; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoVaMasLento; // id para eventos
    public bool isActive = true;


    void Start()
    {
        currentState = State.StateFollow;
    }

    void Update()
    {
        CheckState();
        if (currentState == State.StateTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space)){ 
                StopTurn();
                Follow();
            }
        }

        if (currentState == State.StateFollow)
        {
            if (!Input.GetKeyDown(KeyCode.Space)) { 
                StopFollow();
                Turn();
            }
        }
    }

    private void CheckState()
    {
        switch (currentState)
        {
            case State.StateFollow:
                StopFollow();
                Turn();
                break;
            case State.StateTurn:
                StopTurn();
                Follow();
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
        currentState = State.StateTurn;
    }

    private void StopTurn()
    {
        currentState = State.StateFollow;
    }

    private void Follow()
    {
        cat.SetDestination(player.position);
        currentState = State.StateFollow;
    }

    private void StopFollow()
    {
        currentState = State.StateTurn;
    }
}
