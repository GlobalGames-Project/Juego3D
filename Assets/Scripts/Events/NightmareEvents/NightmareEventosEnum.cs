using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEventosEnum
{

    public enum EventosEnum
    {
        eventoDisparoRafaga,
        eventoDisparoRacimo,
        eventoNoPuedeCaminar,
        eventoMasVida,
        eventoCamara,
        eventoGato,
        eventoMenosVida,
        eventoCaenGotas,
        eventoConsejo,
        eventoSaltasMas,
        eventoElSueloResvala,
        eventoVaMasLento,
        eventoDisparoAutomatico,
        eventoPadreVaMasLento,
        evenoCAenLibros,

        size
    }

    public NightmareEvento[] eventos = {
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null
    };
}

