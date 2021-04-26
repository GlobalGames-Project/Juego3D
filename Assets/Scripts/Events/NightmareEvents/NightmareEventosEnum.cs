using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEventosEnum
{

    public enum EventosEnum
    {
        eventoNoPuedeCaminar,
        eventoCamara,
        eventoSaltasMas,
        eventoVaMasLento,

        size
    }

    public static PlayerEvents[] eventos = {
        ScriptableObject.CreateInstance<OnlyCanRun>(),
        ScriptableObject.CreateInstance<ChangeCameraEvents>(),
        ScriptableObject.CreateInstance<MoreJumpForce>(),
        ScriptableObject.CreateInstance<LessVelocity>(),
    };
}

