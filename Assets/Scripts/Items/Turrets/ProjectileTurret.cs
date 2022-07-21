using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTurret : Turret
{
    [SerializeField] private Transform _projectilesHolder;
    [Space]
    [SerializeField] private ProjectileSpawner _projectileSpawner;
    

    private int _currentProjectile;
    private int _maxAmountOfProjectiles;

    public override void Init(Rigidbody2D owner)
    {
        _owner = owner;
        _turretAnimator = GetComponent<Animator>();
        _maxAmountOfProjectiles = (int)Mathf.Ceil(_turretData.ProjectileData.LifeTime / (60f / _turretData.FireRate));
        _projectileSpawner.LoadTurret(_turretData.ProjectileData, _maxAmountOfProjectiles, owner.gameObject);
    }
    public override void Shoot(bool isShooting)
    {
        _isShooting = isShooting;
        StartCoroutine(ShootingDelay());
    }
    private IEnumerator ShootingDelay()
    {
        while (_isShooting)
        {
            _turretAnimator.SetTrigger("Shooting");
            _projectileSpawner.ShootProjectile(_currentProjectile, _owner);
            _currentProjectile++;
            if (_currentProjectile == _maxAmountOfProjectiles) _currentProjectile = 0;
            yield return new WaitForSeconds(60f / _turretData.FireRate);
        }
    }
}
