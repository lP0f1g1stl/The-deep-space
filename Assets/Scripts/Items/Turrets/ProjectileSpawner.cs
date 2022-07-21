using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private Projectile[] _projectiles;

    public void LoadTurret(AmmoData projectileData, int maxAmmunitionAmount, GameObject owner)
    {
        _projectiles = new Projectile[maxAmmunitionAmount];
        for (int i = 0; i < maxAmmunitionAmount; i++)
        {
            Projectile projectile = Instantiate(projectileData.Prefab);//,_projectilesHolder.transform);
            projectile.SetData(owner);
            projectile.gameObject.SetActive(false);
            _projectiles[i] = projectile;
        }
    }
    public void ShootProjectile(int currentProjectile, Rigidbody2D owner)
    {
        _projectiles[currentProjectile].gameObject.SetActive(true);
        _projectiles[currentProjectile].transform.position = transform.position;
        _projectiles[currentProjectile].transform.rotation = transform.rotation;
        _projectiles[currentProjectile].SetVelocity(owner.velocity);
    }
}
