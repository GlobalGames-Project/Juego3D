using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraMovement {

    public float mouseSensibility = 200f;
    private Transform playerBody;
    private Camera camera;

    private float rotationX = 0f;

    public CameraMovement(GameObject player, Camera mainCamera) {
        camera = mainCamera;
        playerBody = player.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Movement() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void StartRotationWallRun() {
        
    }
}
