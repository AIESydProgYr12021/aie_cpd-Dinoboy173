using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputType : MonoBehaviour
{
    public bool MK = false;
    public bool touch = false;
    public bool controller = false;

    // touch objects
    public GameObject moveJoystick = null;
    public GameObject lookJoystick = null;
    public GameObject virtualJump = null;
    public GameObject virtualPause = null;

    void Update()
    {
        if (MK)
        {

        }

        if (touch)
        {
            moveJoystick.gameObject.SetActive(true);
            lookJoystick.gameObject.SetActive(true);
            virtualJump.gameObject.SetActive(true);
            virtualPause.gameObject.SetActive(true);
        }
        else
        {
            moveJoystick.gameObject.SetActive(false);
            lookJoystick.gameObject.SetActive(false);
            virtualJump.gameObject.SetActive(false);
            virtualPause.gameObject.SetActive(false);
        }

        if (controller)
        {
            
        }
    }
}
