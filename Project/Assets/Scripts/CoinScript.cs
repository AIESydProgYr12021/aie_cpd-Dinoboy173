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
        yOrigin = transform.position.y;
    }

    void Update()
    {
        yRotation += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, yRotation, 90f);

        posChange = transform.right * bobSpeed;
        transform.localPosition += posChange * Time.deltaTime;

        if (transform.localPosition.y <= (yOrigin - bobRange) || transform.localPosition.y >= (yOrigin + bobRange))
        {
            bobSpeed = -bobSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        coinCounter.coinsCollected += 1;
    }
}