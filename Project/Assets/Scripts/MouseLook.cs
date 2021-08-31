using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Canvas canvas = null;

    public float mouseSensitivity = 1f;
    public Transform playerBody;
    private float xRotation = 0f;
    private float yRotation = 0f;
    public GameObject cameraPivot = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // up down
        yRotation += mouseX; // left right

        xRotation = Mathf.Clamp(xRotation, -72, 72);

        cameraPivot.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX * (mouseSensitivity / 100));
    }
}