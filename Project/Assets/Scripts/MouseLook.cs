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

    float mouseX = 0f;
    float mouseY = 0f;

    public float touchTurnSpeed = 2f;

    public VirtualJoystick joystick;

    bool isMK;
    bool isTouch;

    private void Start()
    {
        isMK = FindObjectOfType<InputType>().MK;
        isTouch = FindObjectOfType<InputType>().touch; // gets bool from another script
    }

    void Update()
    {
        isMK = FindObjectOfType<InputType>().MK;
        isTouch = FindObjectOfType<InputType>().touch; // gets bools from another script

        if (isMK)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // gets mouse x and y input
        }

        if (isTouch) 
        {
            mouseX = joystick.Direction.x * touchTurnSpeed;
            mouseY = -joystick.Direction.z * touchTurnSpeed; // touch x and y input
        }

        xRotation -= mouseY; // up down
        yRotation += mouseX; // left right

        xRotation = Mathf.Clamp(xRotation, -72, 72);

        cameraPivot.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // rotates camera up and down
        playerBody.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f); // rotates player left and right
    }
}