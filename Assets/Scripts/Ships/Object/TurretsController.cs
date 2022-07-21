using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsController : MonoBehaviour
{
    [SerializeField] private TurretHolder[] _turretHolders;

    private Rigidbody2D _owner;

    public void Init(Rigidbody2D owner)
    {
        _owner = owner;
        foreach (TurretHolder turretHolder in _turretHolders)
        {
            turretHolder.Turret.Init(_owner);
        }
    }
    public void SetTurret(Turret turret, int turretNumber)
    {
        {
            if (_turretHolders[turretNumber].Turret != null)
            {
                _turretHolders[turretNumber].Turret.RemoveTurret();
            }
            _turretHolders[turretNumber].Turret = Instantiate(turret, _turretHolders[turretNumber].transform);
            _turretHolders[turretNumber].Turret.Init(_owner);
        }
    }
    public void Shoot(bool isShooting)
    {
        foreach (TurretHolder turretHolder in _turretHolders)
        {
            if (turretHolder.Turret != null)
            {
                turretHolder.Turret.Shoot(isShooting);
            }
            else
            {
                Debug.Log("Captain we lost turret!");
            }
        }
    }
}
