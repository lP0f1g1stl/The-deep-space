using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/CreateNewPlayerData", fileName = "NewPlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int _money;
    [SerializeField] private int _shipID;
    [SerializeField] private int _curHP;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _curSP;
    [SerializeField] private int _maxSP;
    [SerializeField] private int _curVolume;
    [SerializeField] private int _maxVolume;


    public int Money 
    {
        get => _money;
        set => _money = value; 
    }
    public int ShipID 
    { 
        get => _shipID; 
        set => _shipID = value; 
    }
    public int CurHP
    {
        get => _curHP;
        set => _curHP = value;
    }
    public int MaxHP
    {
        get => _maxHP;
        set => _maxHP = value;
    }
    public int CurSP
    {
        get => _curSP;
        set => _curSP = value;
    }
    public int MaxSP
    {
        get => _maxSP;
        set => _maxSP = value;
    }
    public int CurVolume
    {
        get => _curVolume;
        set => _curVolume = value;
    }
    public int MaxVolume
    {
        get => _maxVolume;
        set => _maxVolume = value;
    }

}
