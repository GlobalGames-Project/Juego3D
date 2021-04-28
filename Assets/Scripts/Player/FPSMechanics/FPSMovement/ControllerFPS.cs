using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFPS : MonoBehaviour
{

    public enum State { walking, running, jumping, crounching, wallRunning, doubleJumping, climb }
    public State currentState;

    public LayerMask suelo;
    public LayerMask pared;
    public LayerMask climb;
    public LayerMask everything;
    private float timeNotCheckingGround;
    private float timeNotCheckingWallrun;
    private float timeNotCheckingClimb;
    private bool canWalk = true;

    [SerializeField]
    CameraMovement camera;
    [SerializeField]
    public PlayerMovementFPS movemenet;


    void Start()
    {
       
        movemenet = new PlayerMovementFPS(this.gameObject, suelo, pared, climb, everything);
        camera = new CameraMovement(this.gameObject, this.transform.GetChild(1).GetComponent<Camera>());
    }

    private void FixedUpdate()
    {
        movemenet.Move(currentState);

    }

    private void OnCollisionStay(Collision collision)
    {
        LayerMask layer = collision.gameObject.layer;
        if (((LayerMask.GetMask("Default") & 1 << layer) == 1 << layer))
        {
            movemenet.evoidGettingStuck();
        }
    }

    void Update()
    {
        CheckState();
        camera.Movement();
        if (currentState == State.wallRunning)
        {
            movemenet.WallRun();
            camera.StartRotationWallRun(movemenet.getSide());
            if (Input.GetKeyUp(KeyCode.W) || !movemenet.WallRunCheck()) { StopWallRun(); }
        }
        else { camera.StopRotationRun(); }

        if (currentState == State.climb)
        {
            if (!Input.GetKey(KeyCode.W) || !movemenet.checkClimb()) { StopClimb(); }
            movemenet.Climb();
        }
    }

    private void CheckState()
    {
        switch (currentState)
        {
            case State.walking:
                Jump();
                Run();
                Crounch();
                Climb();
                break;
            case State.running:
                Jump();
                StopRun();
                Slide();
                Climb();
                break;
            case State.jumping:
                Jump();
                CheckGround();
                WallRun();
                Climb();
                break;
            case State.doubleJumping:
                CheckGround();
                WallRun();
                Climb();
                break;
            case State.crounching:
                Jump();
                Run();
                StopCrounch();
                Climb();
                break;
            case State.wallRunning:
                Jump();
                break;
            case State.climb:
                Jump();
                break;
        }
    }

    private void Jump()
    {
        if (InputsFPS.Jump())
        {
            if (currentState == State.jumping)
            {
                currentState = State.doubleJumping;
            }
            else
            {

                if (currentState == State.wallRunning) { StopWallRun(); }
                if (currentState == State.climb) { StopClimb(); }
                if (currentState == State.crounching) { movemenet.StopCrounch(); }

                timeNotCheckingGround = Time.time + 1;
                currentState = State.jumping;
            }
            movemenet.Jump();
        }
    }

    private void CheckGround()
    {
        if (movemenet.GroundCheck() && timeNotCheckingGround <= Time.time) { currentState = State.walking; }
    }

    private void Run()
    {
        if (InputsFPS.Run())
        {
            if (currentState == State.crounching) { movemenet.StopCrounch(); }
            movemenet.StartSprint();
            currentState = State.running;
        }
    }

    private void Slide()
    {
        if (InputsFPS.Crounch())
        {
            movemenet.Slide();
            currentState = State.crounching;
        }
    }

    private void StopRun()
    {
        if (InputsFPS.StopRun())
        {
            movemenet.StopSprint();
            currentState = State.walking;
        }
    }

    private void Crounch()
    {
        if (InputsFPS.Crounch())
        {
            movemenet.StartCrounch();
            currentState = State.crounching;
        }
    }

    private void StopCrounch()
    {
        Debug.Log(movemenet.HeadCheck());
        if (InputsFPS.Crounch() && !movemenet.HeadCheck())
        {
            movemenet.StopCrounch();
            currentState = State.walking;
        }
    }

    private void WallRun()
    {
        if (movemenet.WallRunCheck() && timeNotCheckingWallrun <= Time.time)
        {
            currentState = State.wallRunning;
            movemenet.StartWallRun();

        }
    }

    private void StopWallRun()
    {
        movemenet.StopWallRun();
        timeNotCheckingWallrun = Time.time + 1;

        currentState = State.jumping;
    }

    private void StopClimb()
    {
        if (currentState == State.climb || movemenet.checkClimb())
        {
            movemenet.StopClimb();
            timeNotCheckingClimb = Time.time + 1;

            currentState = State.walking;
        }
    }

    public void Climb()
    {
        if (movemenet.checkClimb() && timeNotCheckingClimb <= Time.time)
        {
            currentState = State.climb;
            movemenet.StartClimb();
        }
    }
}