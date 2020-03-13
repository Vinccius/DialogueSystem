using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        Instance = this;
    }

    public event Action<int> OnDoorwayTriggerEnter;

    public void DoorwayTriggerEnter(int id)
    {
        if (OnDoorwayTriggerEnter != null)
        {
            OnDoorwayTriggerEnter.Invoke(id);
        }
    }

    public event Action<int> OnDoorwayTriggerExit;

    public void DoorwayTriggerExit(int id)
    {
        if (OnDoorwayTriggerExit != null)
        {
            OnDoorwayTriggerExit.Invoke(id);
        }
    }

    public event Action OnDialialogueStart;

    public void DialogueStart()
    {
        if(OnDialialogueStart != null)
        {
            OnDialialogueStart.Invoke();
        }
    }

    public event Action OnDialogueEnd;

    public void EndDialogue()
    {
        if(OnDialogueEnd != null)
        {
            OnDialogueEnd.Invoke();
        }
    }
}
