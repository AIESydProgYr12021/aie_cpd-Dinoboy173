using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if (!player.isAlive)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(sceneName: currentScene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player.isAlive = false;
    }
}