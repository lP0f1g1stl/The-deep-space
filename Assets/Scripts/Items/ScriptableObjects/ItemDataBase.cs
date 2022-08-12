using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/CreateNewItemDataBase", fileName = "NewItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private ItemBaseData[] _other;
    [SerializeField] private ItemBaseData[] _turrets;
    [SerializeField] private ItemBaseData[] _engines;
    [SerializeField] private ItemBaseData[] _shields;
    [SerializeField] private ItemBaseData[] _ammo;

    public ItemBaseData GetItemData(ItemType itemType, int itemID) 
    {
        switch (itemType) 
        {
            case ItemType.Turret: return _turrets[itemID];
            case ItemType.Shield: return _shields[itemID];
            case ItemType.Engine: return _engines[itemID];
            case ItemType.Ammo: return _ammo[itemID];
            case ItemType.Other: return _other[itemID];
            default: return null;
        }
    }
}
