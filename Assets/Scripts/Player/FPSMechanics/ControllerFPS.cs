using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFPS : MonoBehaviour {

    public enum State { walking, running, jumping, crounching, wallRunning, doubleJumping}
    public State currentState;

    public LayerMask suelo;
    public LayerMask pared;
    private float timeNotCheckingGround;
    private float timeNotCheckingWallrun;

    [SerializeField]
    CameraMovement camera;
    [SerializeField]
    PlayerMovementFPS movemenet;


    void Start() {
        movemenet = new PlayerMovementFPS(this.gameObject, suelo, pared);
        camera = new CameraMovement(this.gameObject, this.transform.GetChild(1).GetComponent<Camera>());
    }

    private void FixedUpdate() {
        movemenet.Move(currentState);
    }

    void Update() {
        CheckState();
        camera.Movement();
        if (currentState == State.wallRunning) {
            movemenet.WallRun();
   //         camera.StartRotationWallRun();
            if (Input.GetKeyUp(KeyCode.W) || !movemenet.WallRunCheck()) { StopWallRun(); }
          
        }
    }

    private void CheckState() {
        switch (currentState) {
            case State.walking:
                Jump();
                Run();
                Crounch();
                break;
            case State.running:
                Jump();
                StopRun();
                Slide();
                break;
            case State.jumping:
                Jump();
                CheckGround();
                WallRun();
                break;
            case State.doubleJumping:
                CheckGround();
                WallRun();
                break;
            case State.crounching:
                Jump();
                Run();
                StopCrounch();
                break;
            case State.wallRunning:
                Jump();
                break;
        }
    }

    private void Jump() {
        if (InputsFPS.Jump()) {
            if (currentState == State.jumping) {
                currentState = State.doubleJumping;
            }
            else {
                if (currentState == State.wallRunning) {
                    StopWallRun();
                }
                if (currentState == State.crounching) { movemenet.StopCrounch(); }
                timeNotCheckingGround = Time.time + 1;
                currentState = State.jumping;
            }
            movemenet.Jump();
        }
    }

    private void CheckGround() {
        if (movemenet.GroundCheck() && timeNotCheckingGround <= Time.time) { currentState = State.walking; }
    }

    private void Run() {
        if (InputsFPS.Run()) {
            if (currentState == State.crounching) { movemenet.StopCrounch(); }
            movemenet.StartSprint();
            currentState = State.running;
        }
    }

    private void Slide() {
        if (InputsFPS.Crounch()) {
            movemenet.Slide();
            currentState = State.crounching;
        }
    }

    private void StopRun() {
        if (InputsFPS.StopRun()) {
            movemenet.StopSprint();
            currentState = State.walking;
        }
    }

    private void Crounch() {
        if (InputsFPS.Crounch()) {
            movemenet.StartCrounch();
            currentState = State.crounching;
        }
    }

    private void StopCrounch() {
        if (InputsFPS.Crounch()) {
            movemenet.StopCrounch();
            currentState = State.walking;
        }
    }

    private void WallRun() {
        if (movemenet.WallRunCheck() && timeNotCheckingWallrun <= Time.time) {
            currentState = State.wallRunning;
            movemenet.StartWallRun();
        }
    }

    private void StopWallRun() {
        movemenet.StopWallRun();
        timeNotCheckingWallrun = Time.time + 1;
        
        currentState = State.jumping;
    }
}
