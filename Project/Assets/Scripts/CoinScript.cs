using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinCount coinCounter;

    public float rotationSpeed = 15f;
    float yRotation = 0f;

    public float bobSpeed = 10f;
    public float bobRange = 0.1f;
    Vector3 posChange;
    float yOrigin = 0f;

    void Start()
    {
        yOrigin = transform.position.y; // get starting position
    }

    void Update()
    {
        yRotation += rotationSpeed * Time.deltaTime; // add rotation
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
        Destroy(gameObject); // deletes object
        coinCounter.coinsCollected += 1; // adds to counter

        // play sound
    }
}