using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFPS : MonoBehaviour {

    public enum State { walking, running, jumping, crounching, wallRunning, doubleJumping}
    public State currentState;

    public LayerMask suelo;
    float timeNotCheckingGround;
    float timeToResetForcesAfterSliding = 10f;

    [SerializeField]
    CameraMovement camera;
    [SerializeField]
    PlayerMovementFPS movemenet;


    void Start() {
        movemenet = new PlayerMovementFPS(this.gameObject, suelo);
        camera = new CameraMovement(this.gameObject, this.transform.GetChild(1).GetComponent<Camera>());
    }

    private void FixedUpdate() {
        movemenet.Move();
        
    }

    void Update() {
        CheckState();
        camera.Movement();
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
                break;
            case State.doubleJumping:
                CheckGround();
                break;
            case State.crounching:
                Jump();
                Run();
                StopCrounch();
                break;
        }
    }

    private void Jump() {
        if (InputsFPS.Jump()) {
            movemenet.Jump();
            if (currentState == State.jumping) { currentState = State.doubleJumping; }
            else {
                if (currentState == State.crounching) { movemenet.StopCrounch(); }
                timeNotCheckingGround = Time.time + 1;
                currentState = State.jumping;
            }
        }
    }

    private void CheckGround() {
        if (movemenet.GroundCheck() && timeNotCheckingGround <= Time.time) { currentState = State.walking; }
    }

    private void Run() {
        if (InputsFPS.Run()) {
            if (currentState == State.crounching) { movemenet.StopCrounch(); }
            movemenet.Sprint();
            currentState = State.running;
        }
    }

    private void Slide() {
        if (InputsFPS.Crounch()) {
            movemenet.Slide();
            currentState = State.crounching;
            timeToResetForcesAfterSliding = Time.time + 1;
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
            movemenet.Crounch();
            currentState = State.crounching;
        }
    }

    private void StopCrounch() {
        if (InputsFPS.Crounch()) {
            movemenet.StopCrounch();
            currentState = State.walking;
        }
    }
}
