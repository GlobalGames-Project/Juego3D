using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovementFPS
{

    private GameObject player;
    private Rigidbody rb;

    private Vector3 playerScale;
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);

    public float speed = normalSpeed;

    public static float normalSpeed = 10f;
    public static float runningSpeed = 20f;
    public static float crounchingSpeed = 5f;

    public float slideForce = 400f;
    public float jumpForce = 30f;
    public float doubleJumpForce = 50f;

    private Transform groundCheck;
    private LayerMask groundMask;
    private float groundDistance = 0.4f;

    private LayerMask wallRunMask;
    private bool isWallRight, isWallLeft;
    public float wallrunForce = 100f, maxWallSpeed = 20f;

    public PlayerMovementFPS(GameObject currentPlayer, LayerMask suelo, LayerMask pared)
    {
        player = currentPlayer;
        rb = currentPlayer.GetComponent<Rigidbody>();
        groundCheck = currentPlayer.transform.GetChild(0).transform;
        groundMask = suelo;
        playerScale = player.transform.localScale;
        wallRunMask = pared;
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        player.transform.Translate(x, 0, z);
    }

    public void Sprint()
    {
        speed = runningSpeed;
    }

    public void StopSprint()
    {
        speed = normalSpeed;
    }

    public void Slide()
    {
        Crounch();
        rb.AddForce(player.transform.forward * slideForce);
    }

    public void Crounch()
    {
        speed = crounchingSpeed;
        player.transform.localScale = crouchScale;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
    }

    public void StopCrounch()
    {
        speed = normalSpeed;
        player.transform.localScale = playerScale;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }

    public void Jump()
    {
        rb.AddForce(player.transform.up * jumpForce, ForceMode.Impulse);
    }

    public void DoubleJump()
    {
        rb.AddForce(player.transform.up * doubleJumpForce, ForceMode.Impulse);
    }

    public bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public bool WallRunCheck()
    {
        isWallRight = Physics.Raycast(player.transform.position, player.transform.right, 1f, wallRunMask);
        isWallLeft = Physics.Raycast(player.transform.position, -player.transform.right, 1f, wallRunMask);

        if (isWallLeft || isWallRight) Debug.Log("sanganchao");

        
        return isWallLeft || isWallRight;
    }

    public void StartWallRun() {
        ResetForces();
        rb.useGravity = false;
    }

    public void WallRun() {
       
        if (rb.velocity.magnitude <= maxWallSpeed) {
            
           rb.AddForce(-player.transform.up * wallrunForce * Time.deltaTime);

            if (isWallRight)
                rb.AddForce(player.transform.right * wallrunForce * Time.deltaTime);
            else
                rb.AddForce(-player.transform.right * wallrunForce * Time.deltaTime);
        }
    }

    public void StopWallRun() {
        ResetForces();
        rb.useGravity = true;
    }

    private void ResetForces() {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
}
