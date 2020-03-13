using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GameEvents.Instance.OnDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.Instance.OnDoorwayTriggerExit += OnDoorwayClose;
    }

    void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 1.5f, 1f).setEaseInQuad();
        }
    }

    void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 0.5f, 1f).setEaseOutQuad();
        }
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.Instance.OnDoorwayTriggerExit -= OnDoorwayClose;
    }
}
