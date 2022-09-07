using UnityEngine;
using System;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField] private ItemButtonUI _itemButton;

    public int ItemID { get; set; }
    public ItemType ItemType { get; set; }
    public ItemButtonUI ButtonUI => _itemButton;

    public event Action<int, ItemType> OnButtonClick;

    private void OnEnable()
    {
        _itemButton.Button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        _itemButton.Button.onClick.RemoveListener(OnClick);
    }
    private void OnClick() 
    {
        OnButtonClick?.Invoke(ItemID, ItemType);
    }
}
