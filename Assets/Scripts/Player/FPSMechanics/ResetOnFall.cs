using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnFall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "FallHitbox")
        {
            GameManagerScript.health--;
            transform.position = new Vector3(82, 69, 38);
        }
    }
}
