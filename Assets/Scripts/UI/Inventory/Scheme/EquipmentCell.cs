using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EquipmentCell : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ItemType _itemType;
    [Space]
    [SerializeField] private EquimentCellUI _cellUI;

    private bool _isActive;

    public event Action<EquipmentCell, bool> OnCellClick;
    public EquimentCellUI CellUI => _cellUI;
    public void OnPointerDown(PointerEventData eventData) 
    {
        OnCellClick?.Invoke(this, _isActive);
    }
    public void ChangeActiveState(bool isActive) 
    {
        _isActive = isActive;
    }
}
