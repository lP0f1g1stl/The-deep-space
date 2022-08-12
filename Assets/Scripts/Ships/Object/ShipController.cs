using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _angleChangeFactor;
    [Space]
    [SerializeField] private Rigidbody2D _rb;
    public bool IsBoosted { get; set; }
    public void SetData(float speed, float turnSpeed, float minAngle, float angleChangeFactor)
    {
        _speed = speed;
        _turnSpeed = turnSpeed;
        _minAngle = minAngle;
        _angleChangeFactor = angleChangeFactor;
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
    }
}
