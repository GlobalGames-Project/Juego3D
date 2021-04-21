using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsFPS : MonoBehaviour {

    public static bool Run() { return Input.GetButtonDown("Sprint"); }

    public static bool StopRun() { return Input.GetButtonUp("Sprint"); }

    public static bool Crounch() { return Input.GetButtonDown("Crounch"); }

    public static bool Jump() { return Input.GetButtonDown("Jump"); }
}
