using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public Dialogue dialogue;

    private static Queue<string> sentences;
    static bool estaHablando= false;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

     string activeSentence;
    public float typingSpeed;

    public AudioSource speekAudio;

    public int id; 


    // Start is called before the first frame update
    void Start()
    {
     //   EventGenerator.current.onDialogueShow += conversar;
        sentences = new Queue<string>();
        
    }

    private void conversar(int _id)
    {
        if (id == _id)
        {
            dialoguePanel.SetActive(true);
            estaHablando = true;
            startDialogue();
        }
    }

    void startDialogue()
    {
        
        sentences.Clear();
        foreach (string sentence in this.dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
           
        }
        
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        
        Debug.Log(sentences.Count);
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            estaHablando = false;
            
        }
        else
        {
            activeSentence = sentences.Dequeue();
            displayText.text = activeSentence;
            
        }
        

    }

    private void Update()
    {
        /*
        //Cuando sale el texto que puedas darle a enter para que el dialogo siga
        if (!estaHablando)
        {
            dialoguePanel.SetActive(false);
        }
        */
        
        if(estaHablando && Input.GetKeyDown(KeyCode.Space))
        {
            
            DisplayNextSentence();
        }
    }

    private void OnDestroy()
    {
        EventGenerator.current.onDialogueShow -= conversar;
    }
}
