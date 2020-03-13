using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject Player;
    public float DistanceToObject = 3f;

    private bool HasInteracted;

    public virtual void Interaction()
    {
        HasInteracted = false;
    }

    private void Update()
    {
        if(!HasInteracted && Player != null)
        {
            if(Vector3.Distance(Player.transform.position, transform.position) <= DistanceToObject)
            {
                Interact();
                HasInteracted = true;
            }
        }
    }
    #region Dialogue System
    public virtual void Interact()
    {
        Debug.Log("Interact base class");
    }
    #endregion
}
