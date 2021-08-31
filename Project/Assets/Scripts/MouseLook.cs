using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    public Transform playerBody;
    private float xRotation = 0f;
    private float yRotation = 0f;
    public GameObject cameraPivot = null;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // gets mouse x and y input

        xRotation -= mouseY; // up down
        yRotation += mouseX; // left right

        xRotation = Mathf.Clamp(xRotation, -72, 72);

        cameraPivot.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // rotates camera up and down
        playerBody.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f); // rotates player left and right
    }
}