using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float tiempo = 0.0f; // Tiempo real que transcurre
    public float valHora = 120f; // Valor de lo que es 1h en el juego
    public int horario = 0; // En que horario se encuentra, 0 es el principio y segun cuanto este dividido el dia X es el final
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo >= 1 && tiempo<=1.1)
        {
            EventGenerator.current.MamaTimeEnter();
        }

        if (tiempo >= 2 && tiempo <= 2.5)
        {
            EventGenerator.current.CatTiemEnter();
        }
    }
}
