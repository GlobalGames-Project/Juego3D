using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGenerator : MonoBehaviour
{
    public GameObject[] eventosPrefabs;
    public static EventGenerator current;

    private void Awake()
    {
        current = this;
    }

    // Evento Madre
    public event Action onMamaTimeEnter;
    
    public void MamaTimeEnter()
    {
        if(onMamaTimeEnter!= null)
        {
            onMamaTimeEnter();
        }
    }

    //Evento Gato
    public event Action onCatTimeEnter;
    public void CatTiemEnter()
    {
        if (onCatTimeEnter != null)
        {
            onCatTimeEnter();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        EventGenerator.current.onCatTimeEnter += eliminar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void eliminar()
    {
        GameObject.Destroy(eventosPrefabs[0]);
    }


}
