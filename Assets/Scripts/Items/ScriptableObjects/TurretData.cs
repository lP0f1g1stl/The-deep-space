using UnityEngine;

[CreateAssetMenu(menuName = "ItemData/CreateNewTurret", fileName = "NewTurret")]
public class TurretData : ItemBaseData
{
    [Space]
    [SerializeField] private int _fireRate;
    [SerializeField] private AmmoData _projectileData;
    [SerializeField] private AmmoType _ammoType;
    [Space]
    [SerializeField] private Turret _prefab;

    public int FireRate => _fireRate;
    public AmmoData ProjectileData => _projectileData;
    public AmmoType AmmoType => _ammoType;
    public Turret Prefab => _prefab;
}
