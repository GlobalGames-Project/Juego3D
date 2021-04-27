using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasSuperior : MonoBehaviour
{
    public Vector3 spawn;
    public Quaternion direccion;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Submit"))
        {
            Debug.Log("Escaleras");
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = spawn;
        }
        
    }
}
