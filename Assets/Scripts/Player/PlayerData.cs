using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/CreateNewPlayerData", fileName = "NewPlayerData")]
public class PlayerData : ScriptableObject
{
    public int Money { get; set; }
    public int ShipID { get; set; }
    public int CurHP { get; set; }
    public int MaxHP { get; set; }
    public int CurSP { get; set; }
    public int MaxSP { get; set; }
    public int CurVolume { get; set; }
    public int MaxVolume { get; set; }

}
