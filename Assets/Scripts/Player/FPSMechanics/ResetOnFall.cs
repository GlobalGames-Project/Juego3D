using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnFall : MonoBehaviour
{
    public GameObject mom;
    private int motherSpawned = 0;

    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "FallHitbox")
        {
            GameManagerScript.health--;
            transform.position = new Vector3(82, 69, 38);
        }

        if (other.tag == "Mom")
        {
            GameManagerScript.health = 0;

        }
        if (other.tag == "MomStartChasing")
        {
            mom.SetActive(true);
            if (motherSpawned == 0)
            {
                SoundManagerScript.PlaySound("momSpawn");

            }
            motherSpawned = 1;
        }
    }
}
