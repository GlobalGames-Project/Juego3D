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

    
    public event Action onMamaTimeEnter;
    public event Action onCatTimeEnter;
    public void MamaTimeEnter()
    {
        if(onMamaTimeEnter!= null)
        {
            onMamaTimeEnter();
        }
    }

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
        GameObject.Instantiate(eventosPrefabs[0], Vector3.forward , Quaternion.identity);
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
