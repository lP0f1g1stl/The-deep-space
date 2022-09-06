using System;
public class Inventory : ItemStorage
{
    public event Action<ErrorType>ErrorEvent;

    public PlayerData PlayerData { get; set; }
    public override void ChangeItemAmount(int amount, int itemID, ItemType itemType, StorageType storageType, StorageType targetStorageType)
    {
        if (!CheckVoulme(amount, itemID, itemType))
        {
            ErrorEvent?.Invoke(ErrorType.Voulme);
        }
        else if (!CheckMoney(amount, itemID, itemType)) 
        {
            ErrorEvent?.Invoke(ErrorType.Money);
        }
        else 
        {
            base.ChangeItemAmount(amount, itemID, itemType, storageType, targetStorageType);
        }
    }
    private bool CheckVoulme(int amount, int itemID, ItemType itemType) 
    {
        return amount * ItemDataBase.GetItemData(itemType, itemID).Volume + PlayerData.CurVolume <= PlayerData.MaxVolume;
    }
    private bool CheckMoney(int amount, int itemID, ItemType itemType) 
    {
        return amount* ItemDataBase.GetItemData(itemType, itemID).Price > PlayerData.Money;
    }
    protected override void ShowAmountPanel(int itemID, ItemType itemType, int maxAmount) 
    { 
        if(_targetStorageType == StorageType.EquipmentCell) 
        {
            base.ShowAmountPanel(itemID, itemType, 1);
        }
        else 
        {
            base.ShowAmountPanel(itemID, itemType);
        }
    }
}
