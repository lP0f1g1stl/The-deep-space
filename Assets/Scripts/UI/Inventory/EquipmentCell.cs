using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EquipmentCell : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemType _itemType;

    public event Action OnCellClick;
    public void OnPointerDown(PointerEventData eventData) 
    {
        OnCellClick?.Invoke();
    }
}
