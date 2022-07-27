using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EquipmentCell : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemType _itemType;

    bool _isActive;

    public event Action<bool> OnCellClick;
    public void OnPointerDown(PointerEventData eventData) 
    {
        _isActive = true;
        OnCellClick?.Invoke(_isActive);
    }
}
