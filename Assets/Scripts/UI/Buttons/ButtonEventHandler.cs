using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ButtonEventHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> OnButtonHold;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonHold?.Invoke(true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonHold?.Invoke(false);
    }
}
