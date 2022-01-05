using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent onPointerDownCalls;
    [SerializeField] UnityEvent onPointerUpCalls;

    // Button is Pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDownCalls.Invoke();
    }

    // Button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUpCalls.Invoke();
    }
}
