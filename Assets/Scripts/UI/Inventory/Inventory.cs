public class Inventory : ItemStorage
{
    public PlayerData PlayerData { get; set; }

    protected override void ChangeItemAmount(int amount, int itemID, ItemType itemType, StorageType targetStorageType, StorageType storageType) 
    {
        if (storageType == StorageType.Shop)
        {
            PlayerData.CurVolume += ItemDataBase.GetItemData(itemType, itemID).Volume * amount;
            PlayerData.Money -= ItemDataBase.GetItemData(itemType, itemID).Price * amount;
        }
        else if (storageType == StorageType.Warehouse)
        {
            PlayerData.CurVolume += ItemDataBase.GetItemData(itemType, itemID).Volume * amount;
        }
        else if (storageType == StorageType.EquipmentCell)
        {
            PlayerData.CurVolume += ItemDataBase.GetItemData(itemType, itemID).Volume * amount;
        }
        else if (targetStorageType == StorageType.Shop && storageType == StorageType.Inventory) 
        {
            PlayerData.CurVolume -= ItemDataBase.GetItemData(itemType, itemID).Volume * amount;
            PlayerData.Money += ItemDataBase.GetItemData(itemType, itemID).Price * amount;
        }
        else if (targetStorageType == StorageType.Warehouse && storageType == StorageType.Inventory) 
        {
            PlayerData.CurVolume -= ItemDataBase.GetItemData(itemType, itemID).Volume * amount;
        }
        base.ChangeItemAmount(amount, itemID, itemType, targetStorageType, storageType);
    }
}
