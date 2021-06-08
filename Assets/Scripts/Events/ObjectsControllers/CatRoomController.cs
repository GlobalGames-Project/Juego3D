using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatRoomController : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoAcariciarGato; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoVaMasLento; // id para eventos    
    public bool isActive = true;
    public GameObject light;
    public NavMeshAgent agent;
    public LayerMask whatIsGround;
    public NavMeshAgent cat;
    public Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        light.SetActive(isActive);
    }
    private void OnTriggerStay(Collider other)
    {
        cat.SetDestination(player.position);
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
