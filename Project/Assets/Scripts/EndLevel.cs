using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("End Level");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 1 >= sceneCount)
        {
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
        else
        {
            SceneManager.LoadSceneAsync(currentSceneIndex + 1, LoadSceneMode.Single);
        }
    }
}