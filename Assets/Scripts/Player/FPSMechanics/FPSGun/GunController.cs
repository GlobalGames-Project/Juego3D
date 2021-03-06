﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    enum State { notGrappling, Grappling}
    State currentState;

    public LayerMask enemyGrapple;
    public GameObject projectile;
    private float cooldown;

    public GameObject player, camera;

    Bullet bullet;
    Shoot shoot;
    Gancho gancho;



    void Start() {
        currentState = State.notGrappling;
        camera = this.transform.parent.gameObject;
        player = camera.transform.parent.gameObject;
        gancho = new Gancho(this.transform, camera.transform, player.transform, enemyGrapple);
    }

    void Update() {
        CheckState();
    }

    void LateUpdate() {
        gancho.DrawRope();
    }

    private void CheckState() {
        switch (currentState) {
            case State.notGrappling:
                StartGrapple();
                Shoot();
                break;
            case State.Grappling:
                StopGrapple();
                break;
        }
    }

    private void StartGrapple() {
        if (Input.GetMouseButtonDown(0)) {
            gancho.StartGrapple();
            currentState = State.Grappling;
        }
    }

    private void StopGrapple() {
        if (Input.GetMouseButtonUp(0)) {
            gancho.StopGrapple();
            Destroy(player.GetComponent<SpringJoint>());
            currentState = State.notGrappling;
        }
    }

    private void Shoot() {
        if (Input.GetMouseButtonUp(1) && cooldown <= Time.time) {
            cooldown = Time.time + 1;
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 26f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
        }
    }

    public bool IsGrappling() {
        return gancho.isGrapling && currentState == State.Grappling;
    }

    public Vector3 GetGrapplePoint() { 
        return gancho.GetGrapplePoint() ;
    }
}
