using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemStorage : MonoBehaviour
{
    [SerializeField] private ButtonInfo _itemPrefab;
    [SerializeField] private Transform _contentHolder;

    private List<ButtonInfo> _items = new List<ButtonInfo>();

}
