using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private Canvas canvas = null;

    public void MenuPlay()
    {
        Debug.Log("Play");

        canvas = GetComponentInParent<Canvas>();
        canvas.enabled = false;
        canvas = null;

        canvas = GameObject.FindGameObjectWithTag("LevelSelect").GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.Log("Canvas Not Found");
        }

        canvas.enabled = true;
    }

    public void MenuExit()
    {
        Application.Quit();
    }

    public void PauseReturn()
    {
        Debug.Log("Unpause");

        Time.timeScale = 1;

        canvas = GetComponentInParent<Canvas>();
        canvas.enabled = false;
        canvas = null;

        canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.Log("Not Found");
        }

        canvas.enabled = true;
    }

    public void PauseLeave()
    {
        Debug.Log("Leave");

        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void LevelSelectBack()
    {
        Debug.Log("Back");

        canvas = GetComponentInParent<Canvas>();
        canvas.enabled = false;
        canvas = null;

        canvas = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.Log("Canvas Not Found");
        }

        canvas.enabled = true;
    }

    public void LevelSelectNext()
    {
        Debug.Log("Doesn't Do Anything ATM");
    }

    public void LevelSelectLevel()
    {
        string button = EventSystem.current.currentSelectedGameObject.name;

        if (button == null)
        {
            Debug.Log("Not Found");
        }

        Debug.Log(button);

        SceneManager.LoadScene(sceneName: button);
    }

    public void GamePause()
    {
        Debug.Log("Pause");

        Time.timeScale = 0;

        canvas = GetComponentInParent<Canvas>();
        canvas.enabled = false;
        canvas = null;

        canvas = GameObject.FindGameObjectWithTag("Pause").GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.Log("Canvas Not Found");
        }

        canvas.enabled = true;
    }

    public void Test()
    {
        Debug.Log("Test");

        SceneManager.LoadScene(sceneName: "test");
    }
}