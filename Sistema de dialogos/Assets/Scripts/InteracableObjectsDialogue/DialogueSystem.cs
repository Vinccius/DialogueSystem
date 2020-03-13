using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public GameObject DialogueBox;
    public List<string> dialogueLines = new List<string>();

    [SerializeField] private Button NextButton;
    [SerializeField] private Text DialogueText;
    private int DialogueIndex;

    private void Awake()
    {                
        DialogueBox.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void AddNewDialogue(string[] Lines)
    {
        DialogueIndex = 0;
        dialogueLines = new List<string>();

        foreach(string line in Lines)
        {
            dialogueLines.Add(line);
        }
        //Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        DialogueText.text = dialogueLines[0];
        DialogueBox.SetActive(true);
        NextDialogueFromKeyboardInput();
    }

    public void NextDialogue()
    {
        if(DialogueIndex < dialogueLines.Count - 1)
        {
            DialogueIndex++;            
            DialogueText.text = dialogueLines[DialogueIndex];            
            StartCoroutine(TypeSentences(dialogueLines[DialogueIndex]));
        }
        else
        {
            DialogueBox.SetActive(false);
            GameEvents.Instance.EndDialogue();
        }
    }
    
    public void BackDialogue()
    {
        if (DialogueIndex < dialogueLines.Count + 1)
        {
            DialogueIndex--;
            DialogueText.text = dialogueLines[DialogueIndex];
            StartCoroutine(TypeSentences(dialogueLines[DialogueIndex]));
        }        
    }    

    private IEnumerator TypeSentences(string Sentence)
    {
        DialogueText.text = "";
        foreach(char letter in Sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    public void NextDialogueFromKeyboardInput()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextDialogue();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BackDialogue();
        }
    }

    
}
