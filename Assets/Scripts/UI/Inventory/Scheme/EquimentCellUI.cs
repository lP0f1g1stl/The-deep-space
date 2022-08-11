using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquimentCellUI : MonoBehaviour
{
    [SerializeField] private Image _outline;
    [SerializeField] private Image _itemImage;
    [Space]
    [SerializeField] private Color _defaultOutlineColor;

    public void ChangeOutlineState(bool isActive) 
    {
        _outline.color = isActive ? _defaultOutlineColor : Color.clear;
    }
    public void ChangeItemImage(Sprite newImage) 
    {
        _itemImage.sprite = newImage;
    }
}
