using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // controls weather or not the player is jumping on touch
    public bool jump = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jump = false;
    }
}
