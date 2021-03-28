using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ControllerFPS))]
public class CustomControllerFPS : Editor {

    public override void OnInspectorGUI() {
        ControllerFPS controller = (ControllerFPS) target;
        base.OnInspectorGUI();

    }
}
