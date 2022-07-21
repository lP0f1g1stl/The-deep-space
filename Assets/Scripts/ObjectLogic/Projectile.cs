using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] AmmoData _ammoData;
    [SerializeField] private Rigidbody2D rb;

    private GameObject _ownerShip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != _ownerShip && collision.TryGetComponent(out HealthLogic damageReceiver))
        {
           damageReceiver.ReciveDamage(_ammoData.Damage);
           DestroyProjectile();
        }
    }
    public void SetData(GameObject ownerShip) 
    {
        _ownerShip = ownerShip;
    }
    public void SetVelocity(Vector2 _ownerShipVelocity) 
    {
        StartCoroutine(LifeTimer());
        rb.velocity = transform.up * _ammoData.Speed;
        rb.velocity += _ownerShipVelocity;
    }
    IEnumerator LifeTimer() 
    {
        yield return new WaitForSeconds(_ammoData.LifeTime);
        DestroyProjectile();
    }

    private void DestroyProjectile() 
    {
        gameObject.SetActive(false);
    }
}
