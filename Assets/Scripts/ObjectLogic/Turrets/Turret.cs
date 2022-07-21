using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] protected TurretData _turretData;
    [Space]
    [SerializeField] protected Transform _spawnPoint;

    protected Animator _turretAnimator;
    protected Rigidbody2D _owner;

    protected bool _isShooting;

    public void Rotate() 
    {
        
    }
    public void RemoveTurret()
    {
        Destroy(gameObject);
    }
    public virtual void Init(GameObject owner) { }
    public virtual void Shoot(bool isShooting) { }
}
