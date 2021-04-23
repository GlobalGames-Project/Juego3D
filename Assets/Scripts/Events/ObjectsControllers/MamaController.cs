using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaController : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 movimiento = Vector3.forward;
    int id_dialogo = (int)EnumDialogosId.dialogoMadreInicial; // id para los dialogos

    // Start is called before the first frame update
    void Start()
    {
        EventGenerator.current.onMamaTimeEnter += enterMama;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Lo que tiene que hacer la madre cuando se activa su evento
    private void enterMama()
    {
        EventGenerator.current.DialogueShow(id_dialogo);
        CamaController.talkMom();
    }

    private void OnDestroy()
    {
        EventGenerator.current.onMamaTimeEnter -= enterMama;
    }
    
}
