using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGenerator : MonoBehaviour
{
    public GameObject[] eventosPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(eventosPrefabs[0], Vector3.forward , Quaternion.identity);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
