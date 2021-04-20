using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot {

    public Bullet bullet;

    abstract public void ShootAction();

    public void setBulletType(Bullet bullet) {
        this.bullet = bullet;
    }
}
