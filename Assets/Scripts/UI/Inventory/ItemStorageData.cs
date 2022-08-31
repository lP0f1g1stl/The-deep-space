using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemStorageData/CreateNewItemStorage", fileName = "NewItemStorageData")]
public class ItemStorageData : ScriptableObject
{
    [SerializeField] private List<ItemData> _items;

    public List<ItemData> Items => _items;
}

[System.Serializable]
public class ItemData
{
    [SerializeField] private int _itemID;
    [SerializeField] private int _amount;
    [SerializeField] private ItemType _itemType;

    public void Init(int amount, int itemID, ItemType itemType) 
    {
        _itemID = itemID;
        _amount = amount;
        _itemType = itemType;
    }
    public int ItemID => _itemID;
    public ItemType ItemType => _itemType;
    public int Amount 
    {
        get => _amount;
        set => _amount = value;
    }
}
