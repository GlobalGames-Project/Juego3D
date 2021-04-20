using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour {
    private GunController grappling;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;

    private void Start() {
        grappling = this.gameObject.GetComponent<GunController>();
    }

    void Update()
    {
        if (!grappling.IsGrappling())
        {
            desiredRotation = transform.parent.rotation;
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplePoint() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

}
