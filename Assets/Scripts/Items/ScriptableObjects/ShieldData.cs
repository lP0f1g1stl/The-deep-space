using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData/CreateNewShield", fileName = "NewShield")]
public class ShieldData : ItemBaseData
{
    [Space]
    [SerializeField] private int amountOfShieldPoints;
    [SerializeField] private int regenerationRate;
}
