using System.Collections;
using System.Collections.Generic;
using UnityEngine;

var MainCam : Camera;
var BroCam : Camera;
public class BroCam : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        function Start()
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }

        function Update()
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                cam1.enabled = !cam1.enabled;
                cam2.enabled = !cam2.enabled;
            }
        }
    }
}
