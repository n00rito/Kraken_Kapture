using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;
public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AhmedText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float  typeSpeed = 1;

    private Queue<string> paragraphs = new Queue<string>();

    private bool conversationEnded;
    private bool isTyping;

    private string p;

    private Coroutine typeDialogueCoroutine;
    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //if theres nothing in the queue
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //start a convo
                StartConversation(dialogueText);
            }

            else
            {
                //end convo
                EndConversation();
                return;
            }
        }

        //if there is something in queue
        if (!isTyping) 
        {
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }

        //NPCDialogueText.text = P;
        
        if (paragraphs.Count == 0) 
        {
            conversationEnded = true;
        }
    }

    private void StartConversation(DialogueText dialogueText)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        AhmedText.text = dialogueText.speakerName;

        for (int i = 0; i < dialogueText.paragraphs.Length; i++) 
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        
        }
    }

    private void EndConversation()
    {
        paragraphs.Clear();
        conversationEnded = false;

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator TypeDialogueText(string p)
        {
        float elapsedTime = 0f;

        int charIndex = 0;
        charIndex = Mathf.Clamp(charIndex, 0, p.Length);

        while(charIndex < p.Length)
        {
            elapsedTime += Time.deltaTime + typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);

            NPCDialogueText.text = p.Substring(0, charIndex);

            yield return null;

        }

        NPCDialogueText.text = p;
    }
}


