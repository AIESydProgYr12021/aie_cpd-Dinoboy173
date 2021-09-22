using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformType : MonoBehaviour
{
    public bool PC = false;
    public bool web = false;
    public bool android = false;

    public bool controller = false;

    public GameObject exitButton = null;
    public GameObject controllerCheck = null;
    public GameObject checkMark = null;

    private void Start()
    {
        checkMark.gameObject.SetActive(controller);

        PlayerPrefs.SetInt("controller", 0);
        PlayerPrefs.SetInt("PC", PC ? 1 : 0);
        PlayerPrefs.SetInt("android", android ? 1 : 0);
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (PC)
        {
            exitButton.gameObject.SetActive(true);
            controllerCheck.gameObject.SetActive(false);
        }

        if (web)
        {
            exitButton.gameObject.SetActive(false);
            controllerCheck.gameObject.SetActive(true);
        }

        if (android)
        {
            exitButton.gameObject.SetActive(false);
            controllerCheck.gameObject.SetActive(false);
        }
    }

    public void ControllerCheckbox()
    {
        controller = !controller;

        checkMark.gameObject.SetActive(controller);

        PlayerPrefs.SetInt("controller", controller ? 1 : 0);
        PlayerPrefs.Save();
    }
}
