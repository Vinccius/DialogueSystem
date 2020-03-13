using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : Interactable
{
    public string[] Dialogue;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(Dialogue);
        GameEvents.Instance.DialogueStart();
        Debug.Log("Interacting with object");
    }
}
