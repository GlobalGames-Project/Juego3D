using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateFollow : MonoBehaviour
{
    public NavMeshAgent cat;
    public Transform player;
    private StateMachineCat machineCat;

    private void Awake()
    {
        machineCat = GetComponent<StateMachineCat>();
    }

    // Update is called once per frame
    void Update()
    {
        cat.SetDestination(player.position);
    }
}