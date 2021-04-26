using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherMovement : MonoBehaviour
{
    public int movementSpeed;
    bool final = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (final == false)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * 0;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MomCheckpoint")
        {
            Vector3 pos = transform.position;

            transform.Rotate(0, 90, 0);
            transform.position = new Vector3(pos.x, pos.y + 10, pos.z);
    
        }

        if (other.gameObject.tag == "FinalMomCheckpoint")
        {
            final = true;
        }

    }

}
