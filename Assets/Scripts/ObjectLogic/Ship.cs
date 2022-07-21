using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(HealthLogic), typeof(ShipController))]
public class Ship : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _angleChangeFactor;
    [Space]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private EngineHolder[] _engineHolders;
    [SerializeField] private TurretHolder[] _turretHolders;
    [Space]
    [SerializeField] private float _jetstreamDeltaPos;
    
    public bool IsBoosted { get; set; }

    public void SetData(float speed, float turnSpeed, float minAngle, float angleChangeFactor) 
    {
        _speed = speed;
        _turnSpeed = turnSpeed;
        _minAngle = minAngle;
        _angleChangeFactor = angleChangeFactor;
    }
    private void Start()
    {
        foreach (TurretHolder turretHolder in _turretHolders) ///// test
        {
            turretHolder.Turret.Init(gameObject);
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
            _turretHolders[turretNumber].Turret.Init(gameObject);
        }
    }
    public void CalculateAngles(int angleSign, float angleTarget, float angleShip)
    {
        float JSandShipAngle = angleSign * (angleTarget - angleShip);
        float currentAngle = (JSandShipAngle > 180) ? (360 - JSandShipAngle) : JSandShipAngle;
        if (currentAngle < 1) transform.eulerAngles = new Vector3(0, 0, angleTarget);
        else if (JSandShipAngle < 180)
        {
            ChangeAngle(currentAngle, angleSign);
        }
        else if (JSandShipAngle > 180)
        {
            ChangeAngle(currentAngle, -angleSign);
        }
    }
    private void ChangeAngle(float currentAngle, int angleSign)
    {
        if (currentAngle < _minAngle) _rb.AddTorque(angleSign * _turnSpeed * currentAngle / _angleChangeFactor);
        else _rb.AddTorque(angleSign * _turnSpeed);
    }
    public void ChangeThrust(float thrust)
    {
        float speed = IsBoosted == true ? _speed * 2 : _speed;
        _rb.AddRelativeForce(Vector3.up * thrust * speed, ForceMode2D.Force);
        CheckThrustForAnimation(thrust);
    }
    private void CheckThrustForAnimation(float thrust)
    {
        if (thrust >= 0 && thrust < 0.1f)
        {
            ChangeEngineAnimationPosition(0);
        }
        else if (thrust >= 0.1f && thrust <= 0.5f)
        {
            ChangeEngineAnimationPosition(1);
        }
        else
        {
            ChangeEngineAnimationPosition(2);
        }
    }
    private void ChangeEngineAnimationPosition(int animationPhase) 
    {
        Vector3 jetstreamPosition = new Vector3(0, -_jetstreamDeltaPos * animationPhase, 0);
        foreach (EngineHolder engineHolder in _engineHolders) 
        {
            engineHolder.ChangeAnimationPosition(jetstreamPosition);
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
