using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;

    Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    public float speed = 10f;
    public float jumpForce = 10f;
    public float slideForce = 400f;

    private Vector3 playerScale;
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);

    public bool isGrounded;
    public bool isSprinting;


    private void Start() {
        groundCheck = transform.GetChild(0).transform;
        rb = GetComponent<Rigidbody>();
        playerScale = transform.localScale;
        
    }

    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, z);

        if (Input.GetButtonDown("Jump") && isGrounded) rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        if (Input.GetButtonDown("Sprint")) Sprint(true);

        if (Input.GetButtonUp("Sprint") && isSprinting) Sprint(false);

        if (Input.GetButtonDown("Crounch")) StartCrouch();

        if (Input.GetButtonUp("Crounch")) StopCrouch();
    }

    private void Sprint(bool isWalkToSprint) {
        if (isWalkToSprint) AumentarSpeed();
        else ReducirSpeed();

        isSprinting = !isSprinting;
    }

    private void StartCrouch() {
        transform.localScale = crouchScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        ReducirSpeed();

        if (isSprinting && isGrounded) {
            Slide();
            rb.AddForce(transform.forward * slideForce);
        }
    }

    private void StopCrouch() {
        AumentarSpeed();

        transform.localScale = playerScale;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }

    public void Slide() {
        
    }

    public void ReducirSpeed() {
        speed = speed / 2;
    }

    public void AumentarSpeed() {
        speed = speed * 2;
    }
}
