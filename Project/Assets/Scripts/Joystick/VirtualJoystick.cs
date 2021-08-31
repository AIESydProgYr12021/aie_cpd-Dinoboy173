using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [Header("Tweaks")]
    [SerializeField] private float joystickVisualDistance = 50;
    private Image container;
    private Image joystick;

    private Vector3 direction;
    public Vector3 Direction { get { return direction; } }

    void Start()
    {
        var imgs = GetComponentsInChildren<Image>();
        container = imgs[0]; // Container on parent object
        joystick = imgs[1]; // Joystick on first child
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(container.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / container.rectTransform.sizeDelta.x);
            pos.y = (pos.y / container.rectTransform.sizeDelta.y);

            // pivot might be giving us an offset, adjust it here
            Vector2 p = container.rectTransform.pivot;
            pos.x += p.x - 0.5f;
            pos.y += p.y - 0.5f;

            // clamp values
            float x = Mathf.Clamp(pos.x, -1, 1);
            float y = Mathf.Clamp(pos.y, -1, 1);
            direction = new Vector3(x, 0, y).normalized;

            // move the visual to reflect the inputs
            joystick.rectTransform.anchoredPosition = new Vector3(direction.x * joystickVisualDistance, direction.z * joystickVisualDistance);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = default(Vector3);
        joystick.rectTransform.anchoredPosition = default(Vector3);
    }
}
