using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform perseguirObjectivo;
    private NavMeshAgent cat;

    void Awake()
    {
        cat = GetComponent<NavMeshAgent>();
    }

    [System.Obsolete]
    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        cat.destination = puntoDestino;
        cat.Resume();
    }

    [System.Obsolete]
    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        ActualizarPuntoDestinoNavMeshAgent(perseguirObjectivo.position);
    }

    [System.Obsolete]
    public void DetenerNavMeshAgent()
    {
        cat.Stop();
    }

    public bool HemosLlegado()
    {
        return cat.remainingDistance <= cat.stoppingDistance && !cat.pathPending;
    }
}
