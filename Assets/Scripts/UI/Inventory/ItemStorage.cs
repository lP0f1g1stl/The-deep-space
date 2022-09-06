using System.Collections.Generic;
using UnityEngine;

public abstract class ItemStorage : MonoBehaviour
{
    [SerializeField] protected ButtonInfo _itemPrefab;
    [SerializeField] protected Transform _contentHolder;
    [Space]
    [SerializeField] protected ItemStorageData _storageData; //
    [Space]
    [SerializeField] protected StorageType _storageType;
    [SerializeField] protected StorageType _targetStorageType;

    protected List<ButtonInfo> _itemButtons = new List<ButtonInfo>();

    public ItemDataBase ItemDataBase { get; set; }
    public AmountPanel AmountPanel { get; set; }

    private void OnEnable()
    {
        RefreshUI();
        AmountPanel.OnButtonClick += ChangeItemAmount;
        for(int i = 0; i < _itemButtons.Count; i++) 
        {
            _itemButtons[i].OnButtonClick += ShowAmountPanel;
        }
    }
    private void OnDisable()
    {
        AmountPanel.OnButtonClick -= ChangeItemAmount;
        for (int i = 0; i < _itemButtons.Count; i++)
        {
            _itemButtons[i].OnButtonClick += ShowAmountPanel;
        }
    }
    public void ChangeStorageData(ItemStorageData itemStorageData)
    {
        _storageData = itemStorageData;
    }
    private void RefreshUI()
    {
        for (int i = 0; i < _itemButtons.Count; i++)
        {
            Destroy(_itemButtons[i].gameObject);
        }
        _itemButtons.Clear();
        for (int i = 0; i < _storageData.Items.Count; i++) 
        {
            CreateItemButton(_storageData.Items[i].Amount, _storageData.Items[i].ItemID, _storageData.Items[i].ItemType);
        }
    }
    public virtual void ChangeItemAmount(int amount, int itemID, ItemType itemType, StorageType storageType, StorageType targetStorageType)
    {
        if (amount < 1) return;

        int index = _storageData.Items.FindIndex(i => i.ItemID == itemID && i.ItemType == itemType);
        if (index >= 0)
        {
            if (_storageType == targetStorageType)
            {
                _storageData.Items[index].Amount += amount;
            }
            else if(_storageType == storageType)
            {
                _storageData.Items[index].Amount -= amount;
            }
            if (_storageData.Items[index].Amount <= 0)
            {
                RemoveItemButton(index);
            }
            else
            {
                _itemButtons[index].ButtonUI.ChangeAmount(_storageData.Items[index].Amount.ToString());
            }
        }
        else if (_storageType == targetStorageType)
        {
            _storageData.Items.Add(CreateNewItem(amount, itemID, itemType));
            CreateItemButton(amount, itemID, itemType);
            _itemButtons[_itemButtons.Count - 1].OnButtonClick += ShowAmountPanel;
        }
    }
    private void CreateItemButton(int amount, int itemID, ItemType itemType) 
    {
        ItemBaseData itemData = ItemDataBase.GetItemData(itemType, itemID);
        _itemButtons.Add(Instantiate(_itemPrefab, _contentHolder));
        _itemButtons[_itemButtons.Count - 1].ItemID = itemID;
        _itemButtons[_itemButtons.Count - 1].ItemType = itemType;
        _itemButtons[_itemButtons.Count - 1].ButtonUI.Init(itemData.ItemIcon, itemData.Name, itemData.Description, amount.ToString(), itemData.Volume.ToString(), itemData.Price.ToString());
    }
    private void RemoveItemButton(int index) 
    {
        Destroy(_itemButtons[index].gameObject);
        _storageData.Items.Remove(_storageData.Items[index]);
        _itemButtons.Remove(_itemButtons[index]);
    }
    private ItemData CreateNewItem(int amount, int itemID, ItemType itemType) 
    {
        ItemData itemData = new ItemData();
        itemData.Init(amount, itemID, itemType);
        return itemData;
    }
    protected virtual void ShowAmountPanel(int itemID, ItemType itemType, int maxAmount = 0) 
    {
        int index = _storageData.Items.FindIndex(i => i.ItemID == itemID && i.ItemType == itemType);
        if (maxAmount == 0) maxAmount = _storageData.Items[index].Amount;
        AmountPanel.SetData(maxAmount, itemID, itemType, _storageType, _targetStorageType);
        AmountPanel.gameObject.SetActive(true);
    }
}
