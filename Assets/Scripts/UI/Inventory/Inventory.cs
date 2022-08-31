
public class Inventory : ItemStorage
{
    private PlayerData PlayerData { get; set; }
    /*public override bool AddItem(int itemID, int amount, ItemType itemType)
    {
        bool check = PlayerData.CurVolume + ItemDataBase.GetItemData(itemType, itemID).Volume <= PlayerData.MaxVolume;
        if (check)
        {
            base.AddItem(itemID, amount, itemType);
        }
        return check;
    }*/
}
