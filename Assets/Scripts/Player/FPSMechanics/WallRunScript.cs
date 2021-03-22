using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunScript : MonoBehaviour
{

    //Other
    private Rigidbody rb;

    //Assingables
    public Transform orientation;

    //Sliding
    private Vector3 normalVector = Vector3.up;

    //Wallrunning
    public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxWallSpeed;
    bool isWallRight, isWallLeft;
    bool isWallRunning;
    public float maxWallRunCameraTilt, wallRunCameraTilt;

    private void WallRunInput() // I call this in void Update
    {
        //Wallrun
        if (Input.GetKey(KeyCode.D) && isWallRight) StartWallrun();
        if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallrun();
    }
    private void StartWallrun()
    {
        rb.useGravity = false;
        isWallRunning = true;

        if (rb.velocity.magnitude <= maxWallSpeed)
        {
            rb.AddForce(orientation.forward * wallrunForce * Time.deltaTime);

            //Make the character stick to the wall when he's wallrunning
            if (isWallRight)
                rb.AddForce(orientation.right * wallrunForce / 5 * Time.deltaTime);
            else
                rb.AddForce(-orientation.right * wallrunForce / 5 * Time.deltaTime);
        }
    }
    private void StopWallRun()
    {
        isWallRunning = false;
        rb.useGravity = true;
    }
    private void CheckForWall() // I call this in void Update
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);

        //leave wall run
        if (!isWallLeft && !isWallRight) StopWallRun();

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement>();

        //WallRun Jump
        if (Input.GetButtonDown("Jump") && !playerScript.isGrounded)
        {
            WallJump();
        }
        CheckForWall();
        WallRunInput();

    }

    private void WallJump()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement>();

        //Walljump
        if (isWallRunning)
        {
            //Normal jump
            if (isWallLeft && !Input.GetKey(KeyCode.D) || isWallRight && !Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.up * playerScript.jumpForce * 1.5f);
                rb.AddForce(normalVector * playerScript.jumpForce * 0.5f);
            }

            //Horizontal wallhop
            if (isWallRight || isWallLeft && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) rb.AddForce(-orientation.up * playerScript.jumpForce * 1f);
            if (isWallRight && Input.GetKey(KeyCode.A)) rb.AddForce(-orientation.right * playerScript.jumpForce * 3.2f);
            if (isWallLeft && Input.GetKey(KeyCode.D)) rb.AddForce(orientation.right * playerScript.jumpForce * 3.2f);

            //Always add forward force
            rb.AddForce(orientation.forward * playerScript.jumpForce * 1f);

        }
    }

}
