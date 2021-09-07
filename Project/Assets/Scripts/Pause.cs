using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    Canvas canvas = null;

    private void Start()
    {
        Time.timeScale = 1; // safe check set time to play
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // is escape pressed
        {
            canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>(); // get game canvas

            if (canvas.enabled == true) // if game canvas is showing
            {
                canvas = null; // clear selected canvas

                Debug.Log("Pause");

                Time.timeScale = 0; // pause time

                canvas = GetComponentInParent<Canvas>(); // get current canvas
                canvas.enabled = false; // disable canvas

                canvas = GameObject.FindGameObjectWithTag("Pause").GetComponent<Canvas>(); // get pause canvas

                if (canvas == null) // safe check
                {
                    Debug.Log("Canvas Not Found");
                }

                canvas.enabled = true; // enable canvas
            }
            else // if game canvas is not showing
            {
                Debug.Log("Game");

                Time.timeScale = 1; // resume time

                canvas = GameObject.FindGameObjectWithTag("Pause").GetComponent<Canvas>(); // get pause canvas
                canvas.enabled = false; // disable canvas
                
                canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>(); // get game canvas

                if (canvas == null)
                {
                    Debug.Log("Canvas Not Found");
                }

                canvas.enabled = true; // enables canvas
            }
        }
    }
}
