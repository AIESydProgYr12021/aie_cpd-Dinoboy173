using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    Canvas canvas = null;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.enabled == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
