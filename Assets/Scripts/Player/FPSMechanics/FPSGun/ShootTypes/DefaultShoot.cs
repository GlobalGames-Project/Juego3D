using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShoot : Shoot {

    public override void ShootAction() {
        if (Input.GetButtonDown("Fire1")) {
            //bullet.BulletBehaivour();
            Debug.Log("no");
        }
    }
}
