using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraMovement {

    public float mouseSensibility = 200f;
    private Transform playerBody;
    private Camera camera;

    private float rotationX = 0f;

    public Transform playerCam;
    public float maxWallRunCameraTilt, wallRunCameraTilt;

    private float mouseX;
    private float mouseY;

    private float desiredX;
    private float xRotation;


    public CameraMovement(GameObject player, Camera mainCamera) {
        camera = mainCamera;
        playerBody = player.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Movement() {
        mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

       
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void StartRotationWallRun() {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovementFPS wallrunScript = thePlayer.GetComponent<PlayerMovementFPS>();
        bool wallLeft = wallrunScript.isWallLeft;
        bool wallRight = wallrunScript.isWallRight;

        //Find current look rotation
        Vector3 rot = playerCam.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, desiredX, wallRunCameraTilt);


        //While Wallrunning
        //Tilts camera in .5 second
        if (Math.Abs(wallRunCameraTilt) < maxWallRunCameraTilt && wallRight)
                wallRunCameraTilt += Time.deltaTime * maxWallRunCameraTilt * 2;
        if (Math.Abs(wallRunCameraTilt) < maxWallRunCameraTilt && wallLeft)
                wallRunCameraTilt -= Time.deltaTime * maxWallRunCameraTilt * 2;

            //Tilts camera back again
        if (wallRunCameraTilt > 0 && !wallRight && !wallLeft)
                wallRunCameraTilt -= Time.deltaTime * maxWallRunCameraTilt * 2;
        if (wallRunCameraTilt < 0 && !wallRight && !wallLeft)
                wallRunCameraTilt += Time.deltaTime * maxWallRunCameraTilt * 2;    
            

    }
}
