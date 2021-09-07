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

        canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>(); // gets canvas
    }

    void Update()
    {
        isMK = FindObjectOfType<InputType>().MK; // gets bool from another script

        if (isMK)
        {
            if (canvas.enabled == true)
            {
                Cursor.lockState = CursorLockMode.Locked; // if GUI is enabled lock cursor
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined; // if GUI isn't enabled confine cursor
            }
        }
    }
}