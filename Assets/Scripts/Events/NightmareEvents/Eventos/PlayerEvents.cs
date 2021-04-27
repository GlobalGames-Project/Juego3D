using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerEvents : NightmareEvento
{
    public GameObject player;

    public abstract void Init(GameObject player);
}
