using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {
    public float dmg, maxDistance;

    abstract public void BulletBehaivour();
}
