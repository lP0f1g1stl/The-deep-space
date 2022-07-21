using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShipData/CreateNewShip", fileName = "NewShip")]
[System.Serializable]
public class ShipBaseData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _hp;
    [Space]
    [SerializeField] private float _minAngle;
    [SerializeField] private float _angleFactor;
    [SerializeField] private float _cargoWeight;
    [Space]
    [SerializeField] private string _description;
    [Space]
    [SerializeField] private Sprite _shipIcon;
    [SerializeField] private GameObject _shipPrefab;
    [Space]
    [SerializeField] private ShipType _shipType;

    public int ID => _id;
    public int HP => _hp;
    public float MinAngle => _minAngle;
    public float AngleFactor => _angleFactor;
    public float CargoWeight => _cargoWeight;
    public Sprite ShipIcon => _shipIcon;
    public GameObject ShipPrefab => _shipPrefab;
    public string ShipType => _shipType.ToString();
}
