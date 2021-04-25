using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEventosEnum
{

    public enum EventosEnum
    {
        eventoNoPuedeCaminar,
        eventoMasVida,
        eventoCamara,
        eventoMenosVida,
        eventoSaltasMas,
        eventoVaMasLento,

        size
    }

    public static PlayerEvents[] eventos = {
        ScriptableObject.CreateInstance<OnlyCanRun>(),
        null,
        ScriptableObject.CreateInstance<ChangeCameraEvents>(),
        null,
        ScriptableObject.CreateInstance<MoreJumpForce>(),
        ScriptableObject.CreateInstance<LessVelocity>(),
    };
}

