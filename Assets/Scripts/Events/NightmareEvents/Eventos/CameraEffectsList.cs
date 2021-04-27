using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(menuName = "CameraProfile List")]
public class CameraEffectsList : ScriptableObject
{
    public PostProcessProfile[] profiles;
}
