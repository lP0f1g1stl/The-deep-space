using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AmountPanel : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _button;

    private ItemTransferValidator _validator;

    private int _itemID;
    private ItemType _itemType;

    private StorageType _targetStorageType;
    private StorageType _storageType;

    public event Action<int, int, ItemType, StorageType, StorageType> OnButtonClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _slider.onValueChanged.AddListener(ChangeText);
        _inputField.onValueChanged.AddListener(ChangeSliderValue);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _slider.onValueChanged.RemoveListener(ChangeText);
        _inputField.onValueChanged.RemoveListener(ChangeSliderValue);
    }
    public void SetDataToValidator(ItemDataBase itemDataBase, PlayerData playerData) 
    {
        _validator = new ItemTransferValidator();
        _validator.SetData(itemDataBase, playerData);
    }
    public void SetData(int maxAmount, int itemID, ItemType itemType, StorageType targetStorageType, StorageType storageType) 
    {
        _slider.maxValue = _validator.CheckMaxAmount(maxAmount, targetStorageType);
        _itemID = itemID;
        _itemType = itemType;
        _targetStorageType = targetStorageType;
        _storageType = storageType;
        SetDefault();
    } 
    private void ChangeText(float sliderValue) 
    {
        _inputField.text = sliderValue.ToString();
    }
    private void ChangeSliderValue(string inputFieldValue) 
    {
        _slider.value = int.Parse(inputFieldValue);
    }
    private void OnClick() 
    {
        if (_validator.ValidateChange((int)_slider.value, _itemID, _itemType, _targetStorageType, _storageType))
        {
            OnButtonClick?.Invoke((int)_slider.value, _itemID, _itemType, _targetStorageType, _storageType);
        }
        gameObject.SetActive(false);
    }
    private void SetDefault() 
    {
        _slider.value = 0;
        _inputField.text = "0";
    }
}
