using UnityEngine;

public class ItemDataHandler : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ItemDataBase _itemDataBase;
    [SerializeField] private PlayerData _playerData;
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
            if(storage.TryGetComponent(out Inventory inventory)) 
            {
                inventory.PlayerData = _playerData;
            }
        }
    }
}
