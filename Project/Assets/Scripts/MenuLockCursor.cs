using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLockCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // confines cursor to screen when in menu
    }
}