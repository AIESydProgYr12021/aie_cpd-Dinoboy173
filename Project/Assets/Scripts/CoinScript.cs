using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public float rotationSpeed = 15f;
    float yRotation = 0f;

    public float bobSpeed = 10f;
    public float bobRange = 0.1f;
    Vector3 posChange;
    float yOrigin = 0f;

    void Start()
    {
        yOrigin = transform.position.y;
    }

    void Update()
    {
        yRotation += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, yRotation, 90f); // apply rotation

        posChange = transform.right * bobSpeed; // adds movement
        transform.localPosition += posChange * Time.deltaTime; // applys movement

        if (transform.localPosition.y <= (yOrigin - bobRange) || transform.localPosition.y >= (yOrigin + bobRange)) // changes direction
        {
            bobSpeed = -bobSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        FindObjectOfType<CoinCount>().coinsCollected += 1; // adds to counter

        FindObjectOfType<AudioManager>().Play(RandomCoin());
    }

    string RandomCoin()
    {
        string CoinCollectSound = "CoinCollect"; // the worded name of the coincollect sound without its number - needs to change if naming convention changes
        int num = (int)Random.Range(1f, 2.9f); // chooses a random coincollect sound from 8

        CoinCollectSound += num; // adds the number to the string to get a coincollect sound

        return CoinCollectSound;
    }
}