using UnityEngine;
using System.Collections;

public class State : MonoBehaviour
{

    public Color ColorEstado;

    protected StateMachineCat maquinaDeEstados;

    protected virtual void Awake()
    {
        maquinaDeEstados = GetComponent<StateMachineCat>();
    }

}
