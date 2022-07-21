using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemBaseData : ScriptableObject
{
    [SerializeField] protected int _id;
    [SerializeField] protected int _price;
    [SerializeField] protected int _weight;
    [SerializeField] protected Sprite _itemIcon;
    [SerializeField] protected string _description;
    [SerializeField] protected ItemType _typeOfItem;
    [SerializeField] protected GameObject _prefabTest;

    public int ItemID => _id;
    public int Price => _price;
    public int Weight => _weight;
    public Sprite ItemIcon => _itemIcon;
    public string Description => _description;
    public ItemType TypeOfItem => _typeOfItem;
    public GameObject PrefabTest => _prefabTest;
}
