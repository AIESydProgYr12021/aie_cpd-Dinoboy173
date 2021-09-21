using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public Player player;
    public ParticleSystem dustLand;

    void Start()
    {
        dustLand.Stop();
        player.transform.position = transform.position;
    }
}
