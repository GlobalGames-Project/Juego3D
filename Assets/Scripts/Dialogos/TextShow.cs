﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{

    public GameObject dialoguePanel;
    public GameObject player;

    public string[] dialogoMadre;
    public string[] dialogoPC;
    public string[] dialogoWindow;
    public string[] dialogoEstudiar;
    public string[] dialogoMadrePositivo;
    public string[] dialogoMadreNegativo;
    public string[] dialogoMadreNeutral;

    public TextMeshProUGUI textDialogo;
    public bool isDialogoActive;

    Coroutine auxCorutine;


    private void Start()
    {
        EventGenerator.current.onDialogueShow += AbrirCajaDialogo;
    }
    public void AbrirCajaDialogo(int valor)
    {

        if (isDialogoActive)
        {
            CerrarDialogo();
            StartCoroutine(esperaSolapacionDialogo(valor));
        }
        else
        {
            isDialogoActive = false;
            auxCorutine = StartCoroutine(mostrarDialogo(valor));
        }
    }

    IEnumerator mostrarDialogo(int valor, float time = 0.1f)
    {
        dialoguePanel.SetActive(true);
        string[] dialogo;
        switch (valor)
        {
            case (int)EnumDialogosId.dialogoMadreInicial:
                dialogo = dialogoMadre;
                break;
            case (int)EnumDialogosId.dialogoJugarPC:
                dialogo = dialogoPC;
                break;
            case (int)EnumDialogosId.dialogoAbrirVentana:
                dialogo = dialogoWindow;
                break;
            case (int)EnumDialogosId.dialogoEstudiar:
                dialogo = dialogoEstudiar;
                break;
            case (int)EnumDialogosId.dialogoMadreNegativo:
                dialogo = dialogoMadreNegativo;
                break;
            case (int)EnumDialogosId.dialogoMadreNeutral:
                dialogo = dialogoMadreNeutral;
                break;
            case (int)EnumDialogosId.dialogoMadrePositivo:
                dialogo = dialogoMadrePositivo;
                break;
            default:
                dialogo = null;
                break;
        }

        int total = dialogo.Length;
        string res = "";
        isDialogoActive = true;
        yield return null;// seguridad de 1 null
        for(int i = 0; i < total; i++)
        {
            res = "";
            if (isDialogoActive)
            {
                for(int s = 0; s< dialogo[i].Length; s++)
                {
                    if (isDialogoActive)
                    {
                        res = string.Concat(res, dialogo[i][s]);
                        textDialogo.text = res;
                        yield return new WaitForSeconds(time);
                    }
                    else yield break;
                }
                yield return new WaitForSeconds(0.4f);//Tiempo que dura el dialogo en pantalla
            }
            else yield break; //sale
        }
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Cerramos MSORAR");
        CerrarDialogo();
    }

    IEnumerator esperaSolapacionDialogo(int valor)
    {
        yield return new WaitForEndOfFrame();
        auxCorutine = StartCoroutine(mostrarDialogo(valor));
    }
    
    public void CerrarDialogo()
    {
        isDialogoActive = false;
        if(auxCorutine != null)
        {
            Debug.Log("Deteniendolo");
            StopCoroutine(auxCorutine);
            auxCorutine = null;
        }

        textDialogo.text = "";
        dialoguePanel.SetActive(false);
    }

    private void OnDestroy()
    {
        EventGenerator.current.onDialogueShow -= AbrirCajaDialogo;
    }
}
