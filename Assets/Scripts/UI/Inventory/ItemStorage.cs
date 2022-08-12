using System.Collections.Generic;
using UnityEngine;

public abstract class ItemStorage : MonoBehaviour
{
    [SerializeField] protected ButtonInfo _itemPrefab;
    [SerializeField] protected Transform _contentHolder;
    [Space]
    [SerializeField] protected ItemStorageData _storageData;

    protected List<ButtonInfo> _itemButtons;
    public ItemDataBase ItemDataBase { get; set; }

    public virtual bool AddItem(int itemID, int amount, ItemType itemType) 
    {
        int index = _storageData.Items.FindIndex(i => i.ID == itemID && i.ItemType == itemType);
        if (index >= 0)
        {
            _storageData.Items[index].Amount += amount;
            _itemButtons[index].ButtonUI.ChangeAmount(_storageData.Items[index].Amount.ToString());
        }
        else
        {
            _storageData.Items.Add(CreateItem(itemID, amount, itemType));
            ItemBaseData itemData = ItemDataBase.GetItemData(itemType, itemID);
            _itemButtons[_itemButtons.Count - 1].ButtonUI.Init(itemData.ItemIcon, itemData.Name, itemData.Description, amount.ToString(), itemData.Volume.ToString(), itemData.Price.ToString());
        }
        return true;
    }
    public void RemoveItem(int itemID, int amount, ItemType itemType) 
    {
        int index = _storageData.Items.FindIndex(i => i.ID == itemID && i.ItemType == itemType);
        _storageData.Items[index].Amount -= amount;
        if(_storageData.Items[index].Amount <= 0) 
        {
            _storageData.Items.Remove(_storageData.Items[index]);
        }
    }
    private ItemData CreateItem(int id, int amount, ItemType itemtype) 
    {
        ItemData itemData = new ItemData();
        itemData.Init(id, amount, itemtype);
        return itemData;
    }
}
