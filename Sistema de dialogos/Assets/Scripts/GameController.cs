using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera[] cams;

    private void Start()
    {
        ChangeCam1();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCam1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCam2();
        }
    }

    void ChangeCam1()
    {
        cams[0].gameObject.SetActive(true);
        cams[1].gameObject.SetActive(false);
    }

    void ChangeCam2()
    {
        cams[1].gameObject.SetActive(true);
        cams[0].gameObject.SetActive(false);
    }

}
