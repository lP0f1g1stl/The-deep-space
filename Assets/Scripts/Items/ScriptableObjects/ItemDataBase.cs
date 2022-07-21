using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/CreateNewItemDataBase", fileName = "NewItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private ItemBaseData[] items;

    public ItemBaseData GetObject(int _itemID)
    {
        return items[_itemID];
    }
}
