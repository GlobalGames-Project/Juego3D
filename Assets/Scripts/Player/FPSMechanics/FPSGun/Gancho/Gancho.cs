using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho {
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask enemyGrapple;
    public Transform gunTip, cam, player;
    private float maxDistance = 70f;
    private SpringJoint joint;
    public bool isGrapling;
    public float spring = 18f, damper = 7f, massScale = 4.5f;

    public Gancho(Transform gunTip, Transform cam, Transform player, LayerMask enemyGrapple) {
        this.gunTip = gunTip.GetChild(0).transform;
        this.cam = cam;
        this.player = player;
        this.enemyGrapple = enemyGrapple;
        lr = gunTip.GetComponent<LineRenderer>();
    }

    //Called after Update
   

    public void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, enemyGrapple)) { isGrapling = false; }

         else if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance))
        {
            isGrapling = true;
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        } else { isGrapling = false; }
    }

    public void StopGrapple()
    {
        lr.positionCount = 0;
        joint = null;
    }

    private Vector3 currentGrapplePosition;

    public void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
