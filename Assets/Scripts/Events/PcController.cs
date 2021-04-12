using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PcController : MonoBehaviour
{
    public int id; // id para los dialogos
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }


    private void OnTriggerEnter(Collider other)
    {
        EventGenerator.current.DialogueShow(id);
    }
}
