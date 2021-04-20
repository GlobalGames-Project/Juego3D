using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector3 movement;


    private void Start()
    {
        EventGenerator.current.onDialogueGoing += hablando;
        EventGenerator.current.onDialogueFinish += dejarHablar;
    }

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void hablando()
    {
        moveSpeed = 0f;
    }

    private void dejarHablar()
    {
        moveSpeed = 5f;
    }

    private void OnDestroy()
    {
        EventGenerator.current.onDialogueGoing -= hablando;
        EventGenerator.current.onDialogueFinish -= dejarHablar;
    }
}
