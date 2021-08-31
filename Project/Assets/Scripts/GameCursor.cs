using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    Canvas canvas = null;

    bool isMK;

    void Start()
    {
        isMK = FindObjectOfType<InputType>().MK;

        if (isMK)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();
    }

    void Update()
    {
        isMK = FindObjectOfType<InputType>().MK;

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
