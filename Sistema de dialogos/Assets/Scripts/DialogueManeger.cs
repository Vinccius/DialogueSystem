using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManeger : MonoBehaviour
{
    private Queue<string> Sentences;
    public Text nameText;
    public Text DialogueText;
    public Animator DialogueBox;
        

	// Use this for initialization
	void Start ()
    {
        Sentences = new Queue<string>();
	}
	
	public void StartDialogue (Dialogue dialogue)
    {
        DialogueBox.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        Sentences.Clear();

        foreach (string sentences in dialogue.sentences)
        {
            Sentences.Enqueue(sentences);

        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
         }
    }

    void EndDialogue()
    {
        DialogueBox.SetBool("IsOpen", false);
    }
}
