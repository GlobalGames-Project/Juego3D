using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsCollector : MonoBehaviour
{
    int day;
    Evento[] eventos = new Evento[20];

    public void setDay(int day)
    {
        this.day = day;
    }

    // Start is called before the first frame update
    void Start()
    {
        Evento[] eventosDia;
        if (day == 1)
        {
            float numEvents = Random.Range(3, 6);
            eventosDia = new Evento[(int)numEvents];
            for(int i=0; i < eventosDia.Length; i++)
            {
                eventosDia.[i] = eventos[2]; //Random
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
