using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float tiempo = 0.0f;
    public float valHora = 120f;
    public int horario = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;
        if ((int)tiempo >= 1)
        {
            EventGenerator.current.MamaTimeEnter();
        }

        if ((int)tiempo >= 2)
        {
            EventGenerator.current.CatTiemEnter();
        }
    }
}
