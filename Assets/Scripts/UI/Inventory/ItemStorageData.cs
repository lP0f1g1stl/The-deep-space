using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemStorageData/CreateNewItemStorage", fileName = "NewItemStorageData")]
public class ItemStorageData : ScriptableObject
{
    [SerializeField] private List
}

[System.Serializable]
public struct ItemData 
{
    [SerializeField] private int _itemID;
    [SerializeField] private int _amount;

    public int ItemID => _itemID;
    public int Amount => _amount;
}
