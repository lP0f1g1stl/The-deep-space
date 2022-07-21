using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/CreateNewPlayerData", fileName = "NewPlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int _money;
    [Space]
    [SerializeField] private int _shipID;
    [Header("Health")]
    [SerializeField] private int _curHP;
    [SerializeField] private int _maxHP;
    [Header("Shield")]
    [SerializeField] private int _curSP;
    [SerializeField] private int _maxSP;

    public int Money 
    {
        set => _money = value;
        get => _money;
    }

    public int ShipID 
    {
        set => _shipID = value;
        get => _shipID;
    }
    public int CurHP
    {
        set => _curHP = value;
        get => _curHP;
    }
    public int MaxHP
    {
        set => _maxHP = value;
        get => _maxHP;
    }
    public int CurSP
    {
        set => _curSP = value;
        get => _curSP;
    }
    public int MaxSP
    {
        set => _maxSP = value;
        get => _maxSP;
    }
}
