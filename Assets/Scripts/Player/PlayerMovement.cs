using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController controller;

    Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded = true;
    bool isSprinting;

    private void Start() {
        groundCheck = transform.GetChild(0).transform;
        controller = GetComponent<CharacterController>();
    }

    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {velocity.y = -2;}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        if (Input.GetButtonDown("Sprint")) Sprint(true);

        if (Input.GetButtonUp("Sprint") && isSprinting) Sprint(false);
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Sprint(bool isWalkToSprint) {
        if (isWalkToSprint) speed = speed * 2;
        else speed = speed / 2;

        isSprinting = !isSprinting;
    }
}
