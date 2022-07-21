using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData/CreateNewAmmo", fileName = "NewAmmo")]
public class AmmoData : ItemBaseData
{
    [Space]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private AmmoType _ammoType;
    [Space]
    [SerializeField] private Projectile _prefab;

    public int Damage => _damage;
    public float Speed => _speed;
    public float LifeTime => _lifeTime;
    public AmmoType AmmoType => _ammoType;
    public Projectile Prefab => _prefab;
}

