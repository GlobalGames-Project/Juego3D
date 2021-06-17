using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateTurn : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    private int waypointsIndex;
    private float dist;
     
    public bool isActive = true;
    public GameObject light;
    public LayerMask whatIsGround;
    public Transform player;
    public NavMeshAgent cat;
    private StateMachineCat machineCat;
    private NavMeshController navmeshController;
    
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(isActive);
        transform.LookAt(waypoints[waypointsIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();

        }
        Patrol();
    }

    

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointsIndex++;
        if (waypointsIndex >= waypoints.Length)
        {
            waypointsIndex = 0;
        }
        transform.LookAt(waypoints[waypointsIndex].position);
    }
}