using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovementFPS
{

    private Rigidbody rb;
    private GameObject player;
    private Transform orientation;
    private ControllerFPS.State currentState;

    private Vector3 playerScale;
    private Vector3 crounchScale = new Vector3(1, 0.5f, 1);
    static float crouchGravityMultiplier = 1f;
    public float slideForce = 7000f;

    static float defaultGravityMultiplier = 10f;
    private float actualGravityMultiplayer = defaultGravityMultiplier;

    public float moveSpeed = 4500;
    static float defaultMaxSpeed = 20;
    static float sprintingMaxSpeed = 40;
    float currentMaxSpeed = defaultMaxSpeed;
    float multiplier = 1f, multiplierV = 1f;

    private float threshold = 0.01f;
    public float counterMovement = 0.175f;
    public float slideCounterMovement = 0.2f;

    private Transform groundCheck;
    private LayerMask groundMask;
    private float groundDistance = 0.4f;

    private LayerMask wallRunMask;
    public bool isWallRight, isWallLeft;
    public float wallrunForce = 100f, maxWallSpeed = 20f;

    private LayerMask climbMask;
    public float climbForce = 100000f, maxClimbSpeed = 10f;

    public float jumpForce = 1000f;

    public PlayerMovementFPS(GameObject currentPlayer, LayerMask suelo, LayerMask pared, LayerMask escalada)
    {
        player = currentPlayer;
        rb = currentPlayer.GetComponent<Rigidbody>();
        groundCheck = currentPlayer.transform.GetChild(0).transform;
        groundMask = suelo;
        playerScale = player.transform.localScale;
        wallRunMask = pared;
        climbMask = escalada;
        orientation = player.transform.GetChild(2).transform;
    }

    public void Move(ControllerFPS.State state)
    {
        currentState = state;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.AddForce(Vector3.down * Time.deltaTime * actualGravityMultiplayer);

        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        CounterMovement(x, y, mag);

        if (x > 0 && xMag > currentMaxSpeed) x = 0;
        if (x < 0 && xMag < -currentMaxSpeed) x = 0;
        if (y > 0 && yMag > currentMaxSpeed) y = 0;
        if (y < 0 && yMag < -currentMaxSpeed) y = 0;

        rb.AddForce(orientation.transform.forward * y * moveSpeed * Time.deltaTime * multiplier * multiplierV);
        rb.AddForce(orientation.transform.right * x * moveSpeed * Time.deltaTime * multiplier);
    }

    public void evoidGettingStuck()
    {
        rb.AddForce(-orientation.transform.forward * 1 * moveSpeed * Time.deltaTime * multiplier * multiplierV);
    }

    public void Slide()
    {
        StartCrounch();
        rb.AddForce(orientation.transform.forward * slideForce);
    }

    public void StartCrounch()
    {
        player.transform.localScale = crounchScale;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
    }

    public void StopCrounch()
    {
        actualGravityMultiplayer = defaultGravityMultiplier;
        player.transform.localScale = playerScale;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }

    public void Jump()
    {
        //multiplier = 0.5f;
        //multiplierV = 0.5f;
        rb.AddForce(Vector2.up * jumpForce * 1.5f);

        Vector3 vel = rb.velocity;
        if (rb.velocity.y < 0.5f)
            rb.velocity = new Vector3(vel.x, 0, vel.z);
        else if (rb.velocity.y > 0)
            rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);
    }

    public void StartSprint()
    {
        currentMaxSpeed = sprintingMaxSpeed;
    }

    public void StopSprint()
    {
        currentMaxSpeed = defaultMaxSpeed;
    }

    public bool GroundCheck()
    {
        bool aux = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (aux)
        {
            multiplier = 1f;
            multiplierV = 1f;
        }
        return aux;
    }

    public bool WallRunCheck()
    {
        isWallRight = Physics.Raycast(player.transform.position, orientation.right, 1f, wallRunMask);
        isWallLeft = Physics.Raycast(player.transform.position, -orientation.right, 1f, wallRunMask);

        return isWallLeft || isWallRight;
    }

    public void StartWallRun()
    {
        rb.useGravity = false;
    }

    public void WallRun()
    {

        if (rb.velocity.magnitude <= maxWallSpeed)
        {

            rb.AddForce(orientation.forward * wallrunForce * Time.deltaTime);

            //Make sure char sticks to wall
            if (isWallRight)
                rb.AddForce(orientation.right * wallrunForce / 5 * Time.deltaTime);
            else
                rb.AddForce(-orientation.right * wallrunForce / 5 * Time.deltaTime);
        }
    }

    public void StopWallRun()
    {
        rb.useGravity = true;
    }

    public bool getSide()
    {
        return isWallRight;
    }

    public bool checkClimb() {
        return Physics.Raycast(player.transform.position, orientation.forward, 1, climbMask);
    }

    public void StartClimb()
    {
        rb.useGravity = false;
    }

    public void StopClimb()
    {
        rb.useGravity = true;
    }

    public void Climb()
    {
        Vector3 vel = rb.velocity;
        //if (rb.velocity.y < 0.5f)
        //{
            rb.velocity = new Vector3(vel.x, 0, vel.z);
            rb.AddForce(orientation.forward * 500 * Time.deltaTime);
        //}

        //Push character up
        if (rb.velocity.magnitude < maxClimbSpeed)
            rb.AddForce(orientation.up * climbForce * Time.deltaTime);

        //Doesn't Push into the wall
        
    }




    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = player.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }

    private void CounterMovement(float x, float y, Vector2 mag)
    {
        if (currentState == ControllerFPS.State.jumping || currentState == ControllerFPS.State.doubleJumping) return;

        if (currentState == ControllerFPS.State.wallRunning)
        {
            if (isWallLeft && Input.GetKey(KeyCode.A) || isWallRight && Input.GetKey(KeyCode.D)) { rb.AddForce(player.transform.right * -x * moveSpeed * Time.deltaTime * multiplier); }
        }

        if (currentState == ControllerFPS.State.crounching)
        {
            rb.AddForce(moveSpeed * Time.deltaTime * -rb.velocity.normalized * slideCounterMovement);
            return;
        }

        if (Mathf.Abs(mag.x) > threshold && Mathf.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            rb.AddForce(moveSpeed * orientation.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Mathf.Abs(mag.y) > threshold && Mathf.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            rb.AddForce(moveSpeed * orientation.forward * Time.deltaTime * -mag.y * counterMovement);
        }

        //Limit diagonal running. This will also cause a full stop if sliding fast and un-crouching, so not optimal.
        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > currentMaxSpeed)
        {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * currentMaxSpeed;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }
}