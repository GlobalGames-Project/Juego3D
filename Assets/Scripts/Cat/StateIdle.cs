using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateIdle : MonoBehaviour
{
    int idDialogo = (int)EnumDialogosId.dialogoAcariciarGato; // id para los dialogos
    int idEvent = (int)NightmareEventosEnum.EventosEnum.eventoVaMasLento; // id para eventos    
    public bool isActive = true;
    public GameObject light;
    public LayerMask whatIsGround;
    public Transform player;
    public NavMeshAgent cat;
    private StateMachineCat machineCat;
    private NavMeshController navmeshController;
    public float turnspeed = 120f;
    public float duration = 4f;



    void Awake()
    {
        machineCat = GetComponent<StateMachineCat>();
        navmeshController = GetComponent<NavMeshController>();
    }

    [System.Obsolete]
    void OnEnable()
    {
        navmeshController.DetenerNavMeshAgent();
    }

    private void Start()
    {
        light.SetActive(isActive);
        if (Input.GetButton("Submit"))
        {
            cat.SetDestination(player.position);

        }
    }
    private void OnTriggerStay(Collider other)
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
        if (isActive == false)
        {

        }

    }

    private void Update()
    {
        transform.Rotate(0f, turnspeed * Time.deltaTime, 0f);
    }

}