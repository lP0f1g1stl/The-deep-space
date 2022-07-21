using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/CreateNewShipDataBase", fileName = "NewShipDatabase")]
public class ShipDataBase : ScriptableObject
{
    [SerializeField] private ShipBaseData[] ships;

    public ShipBaseData GetObject(int _shipID)
    {
        return ships[_shipID];
    }
}
