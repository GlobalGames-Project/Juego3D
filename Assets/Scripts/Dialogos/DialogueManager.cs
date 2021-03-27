using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public Dialogue dialogue;

    Queue<string> sentences;
    bool hablando= false;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

     string activeSentence;
    public float typingSpeed;

    public AudioSource speekAudio;

    public int id; 


    // Start is called before the first frame update
    void Start()
    {
        EventGenerator.current.onDialogueShow += conversar;
        sentences = new Queue<string>();
        
    }

    private void conversar(int _id)
    {
        if (id == _id)
        {
            dialoguePanel.SetActive(true);
            hablando = true;
            startDialogue();
        }
    }

    void startDialogue()
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            hablando = false;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
        speekAudio.Play();
    }

    private void Update()
    {
        //Cuando sale el texto que puedas darle a enter para que el dialogo siga
        if (!hablando)
        {
            dialoguePanel.SetActive(false);
        }
        
        if(hablando && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    private void OnDestroy()
    {
        EventGenerator.current.onDialogueShow -= conversar;
    }
}
