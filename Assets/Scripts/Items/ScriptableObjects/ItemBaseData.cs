using UnityEngine;

[System.Serializable]
public abstract class ItemBaseData : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] protected int _price;
    [SerializeField] protected int _volume;
    [SerializeField] protected Sprite _itemIcon;
    [SerializeField] protected string _description;
    [SerializeField] protected ItemType _typeOfItem;
    [Space]
    [SerializeField] protected GameObject _prefabLoot;

    public string Name => _name;
    public int Price => _price;
    public int Volume => _volume;
    public Sprite ItemIcon => _itemIcon;
    public string Description => _description;
    public ItemType TypeOfItem => _typeOfItem;
    public GameObject PrefabLoot => _prefabLoot;
}
