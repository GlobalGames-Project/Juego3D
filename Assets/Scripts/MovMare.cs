using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMare : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    private int waypointsIndex;
    private float dist;

    void Start()
    {
        waypointsIndex = 0;
        transform.LookAt(waypoints[waypointsIndex].position);
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    // Update is called once per frame
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
