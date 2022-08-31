using UnityEngine;

public class ItemDataHandler : MonoBehaviour
{
    [SerializeField] private ItemDataBase _itemDataBase;
    [Space]
    [SerializeField] private AmountPanel _amountPanel;
    [Space]
    [SerializeField] private ItemStorage[] _storages;


    private void Awake()
    {
        foreach(ItemStorage storage in _storages) 
        {
            storage.ItemDataBase = _itemDataBase;
            storage.AmountPanel = _amountPanel;
        }
    }
}
