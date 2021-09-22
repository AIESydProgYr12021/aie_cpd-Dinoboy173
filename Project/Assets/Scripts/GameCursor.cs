using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    Canvas canvas = null;

    bool isMK;

    void Start()
    {
        isMK = FindObjectOfType<InputType>().MK; // gets bool from another script

        if (isMK) // locks cursor to screen if mouse and keyboard controls
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        isMK = FindObjectOfType<InputType>().MK;

        canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();

        if (canvas.enabled == true && isMK)
        {
            Cursor.lockState = CursorLockMode.Locked; // if GUI is enabled lock cursor
        }
        else if (canvas.enabled == false)
        {
            Cursor.lockState = CursorLockMode.None; // if GUI isn't enabled confine cursor
        }
    }
}