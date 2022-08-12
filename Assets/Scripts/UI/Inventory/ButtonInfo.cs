using UnityEngine;
using System;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField] private ItemButtonUI _itemButton;

    public int ItemID { get; set; }
    public ItemButtonUI ButtonUI => _itemButton;

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
