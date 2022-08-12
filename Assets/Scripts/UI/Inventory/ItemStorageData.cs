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
    [SerializeField] private int _id;
    [SerializeField] private int _amount;
    [SerializeField] private ItemType _itemType;

    public void Init(int id, int amount, ItemType itemType) 
    {
        _id = id;
        _amount = amount;
        _itemType = itemType;
    }
    public int ID => _id;
    public ItemType ItemType => _itemType;
    public int Amount 
    {
        get => _amount;
        set => _amount = value;
    }
}
