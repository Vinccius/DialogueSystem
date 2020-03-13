using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;

    private Func<List<GameObject>> OnRequestListOfDoors;

    private void OnTriggerEnter(Collider other)
    {
        GameEvents.Instance.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.Instance.DoorwayTriggerExit(id);
    }

    public void SetOnRequestListOfDoors(Func<List<GameObject>> returnEvent)
    {
        OnRequestListOfDoors = returnEvent;
    }

    public List<GameObject> RequestListOfDoors()
    {
        if(OnRequestListOfDoors != null)
        {
            return OnRequestListOfDoors();
        }

        return null;
    }
}
