using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFPS {

    public GameObject player;
    public Rigidbody rb;

    private Vector3 playerScale;
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);

    public float speed = 10f;
    public float slideForce = 400f;
    public float jumpForce = 10f;

    Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    public PlayerMovementFPS(GameObject currentPlayer, LayerMask suelo) {
        player = currentPlayer;
        rb = currentPlayer.GetComponent<Rigidbody>();
        groundCheck = currentPlayer.transform.GetChild(0).transform;
        groundMask = suelo;
        playerScale = player.transform.localScale;
    }

    public void Move() {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        player.transform.Translate(x, 0, z);
    }

    public void Sprint() {
        speed = speed * 2;
    }

    public void StopSprint() {
        speed = speed / 2;
    }

    public void Slide()
    {
        Crounch();
        rb.AddForce(player.transform.forward * slideForce);
    }

    public void Crounch() {
        speed = speed / 2;
        player.transform.localScale = crouchScale;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
    }

    public void StopCrounch() {
        speed = speed * 2;
        player.transform.localScale = playerScale;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }

    public void Jump() {
        rb.AddForce(player.transform.up * jumpForce, ForceMode.Impulse);
    }

    public bool GroundCheck() {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
