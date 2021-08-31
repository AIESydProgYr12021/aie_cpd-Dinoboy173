using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    Canvas canvas = null;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();

            if (canvas.enabled == true)
            {
                canvas = null;

                Debug.Log("Pause");

                Time.timeScale = 0;

                canvas = GetComponentInParent<Canvas>();
                canvas.enabled = false;

                canvas = GameObject.FindGameObjectWithTag("Pause").GetComponent<Canvas>();

                if (canvas == null)
                {
                    Debug.Log("Canvas Not Found");
                }

                canvas.enabled = true;
            }
            else
            {
                Debug.Log("Game");

                Time.timeScale = 1;

                canvas = GameObject.FindGameObjectWithTag("Pause").GetComponent<Canvas>();
                canvas.enabled = false;
                
                canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();

                if (canvas == null)
                {
                    Debug.Log("Canvas Not Found");
                }

                canvas.enabled = true;
            }
        }
    }
}
