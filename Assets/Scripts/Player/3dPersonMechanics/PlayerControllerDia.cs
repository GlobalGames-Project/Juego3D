﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerControllerDia : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -19.81f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float PlayerSpeed;
    private Vector3 movePlayer;
    private Vector3 PlayerInput;
     
    Vector3 velocity;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        EventGenerator.current.onDialogueGoing += hablando;
        EventGenerator.current.onDialogueFinish += dejarHablar;
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey("a"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey("s"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey("d"))
        {
            anim.SetBool("isWalking", true);
        }
        else if(Input.GetKey("up"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey("left"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey("down"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey("right"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerInput = new Vector3(horizontal, 0, vertical);
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);

        controller.Move(movePlayer * PlayerSpeed * Time.deltaTime);

        SetGravity();

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

        void SetGravity()
        {
            controller.SimpleMove(Physics.gravity);

        }
    }

    private void hablando()
    {
        speed = 0f;
        anim.SetBool("isWalking", false);

    }

    private void dejarHablar()
    {
        speed = 5f;
    }
    private void OnDestroy()
    {
        EventGenerator.current.onDialogueGoing -= hablando;
        EventGenerator.current.onDialogueFinish -= dejarHablar;
    }
}


