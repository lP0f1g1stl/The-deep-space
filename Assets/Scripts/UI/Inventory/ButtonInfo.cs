using UnityEngine;
using System;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField] private ItemButton _itemButton;

    private int ItemID { get; set; }

    public event Action<int> OnButtonClick;

    private void OnEnable()
    {
        _itemButton.Button.onClick.AddListener(() => OnButtonClick?.Invoke(ItemID));
    }
    private void OnDisable()
    {
        _itemButton.Button.onClick.RemoveListener(() => OnButtonClick?.Invoke(ItemID));
    }

}
