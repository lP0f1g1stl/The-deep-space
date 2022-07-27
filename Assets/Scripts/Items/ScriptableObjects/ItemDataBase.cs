using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/CreateNewItemDataBase", fileName = "NewItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private ItemBaseData[] _items;
    [SerializeField] private ItemBaseData[] _turrets;
    [SerializeField] private ItemBaseData[] _engines;
    [SerializeField] private ItemBaseData[] _shields;
    [SerializeField] private ItemBaseData[] _missiles;
    [SerializeField] private ItemBaseData[] _ammo;

    public ItemBaseData GetItem(int id)
    {
        return _items[id];
    }
    public ItemBaseData GetTurret(int id)
    {
        return _turrets[id];
    }
    public ItemBaseData GetEngine(int id)
    {
        return _engines[id];
    }
    public ItemBaseData GetShield(int id)
    {
        return _shields[id];
    }
    public ItemBaseData GetMissile(int id)
    {
        return _missiles[id];
    }
    public ItemBaseData GetAmmo(int id)
    {
        return _ammo[id];
    }
}
