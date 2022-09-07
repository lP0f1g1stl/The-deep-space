using System;
public class ItemTransferValidator
{
    private ItemDataBase _itemDataBase;
    private PlayerData _playerData;

    public event Action<ErrorType> ErrorEvent;

    public void SetData(ItemDataBase itemDataBase, PlayerData playerData) 
    {
        _itemDataBase = itemDataBase;
        _playerData = playerData;
    }

    public int CheckMaxAmount(int amount, StorageType targetStorageType) 
    {
        return targetStorageType == StorageType.EquipmentCell ? 1 : amount; 
    }
    public bool ValidateChange(int amount, int itemID, ItemType itemType, StorageType targetStorageType, StorageType storageType)
    {
        if (storageType == StorageType.Shop)
        {
            bool result = CheckVoulme(amount, itemID, itemType) && CheckMoney(amount, itemID, itemType);
            return result;
        }
        else if (targetStorageType == StorageType.Inventory)
        {
            bool result = CheckVoulme(amount, itemID, itemType);
            return result;
        }
        else return true;
    }
    private bool CheckVoulme(int amount, int itemID, ItemType itemType)
    {
        bool check = amount * _itemDataBase.GetItemData(itemType, itemID).Volume + _playerData.CurVolume <= _playerData.MaxVolume;
        if (!check) 
        {
            ErrorEvent?.Invoke(ErrorType.Voulme);
        }
        return check;
    }
    private bool CheckMoney(int amount, int itemID, ItemType itemType)
    {
        bool check = amount * _itemDataBase.GetItemData(itemType, itemID).Price <= _playerData.Money;
        if (!check)
        {
            ErrorEvent?.Invoke(ErrorType.Money);
        }
        return check;
    }
}
