using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player.transform.position = transform.position;
    }

    void Update()
    {
        if (!player.isAlive)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(sceneName: currentScene);
        }
    }
}
