using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Joystick _jsMovement;
    [SerializeField] private ButtonsHandler _buttons;

    private Ship _ship;

    private bool _onJSDrag;

    public Ship Ship 
    { 
        set => _ship = value; 
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }
    private void OnEnable()
    {
        _jsMovement.OnJSDrag += CheckJSState;
        _buttons.Shoot.OnButtonHold += Shoot;
        _buttons.Boost.OnButtonHold += Boost;
        _buttons.Missile.onClick.AddListener(LaunchMissile);
    }
    private void OnDisable()
    {
        _jsMovement.OnJSDrag -= CheckJSState;
        _buttons.Shoot.OnButtonHold -= Shoot;
        _buttons.Boost.OnButtonHold -= Boost;
        _buttons.Missile.onClick.RemoveListener(LaunchMissile);
    }
    private void CheckJSState(bool onDrag) 
    {
        _onJSDrag = onDrag;
        if (!_onJSDrag) 
        {
            _ship.ChangeThrust(0);
        }
    }
    private void PlayerMovement() 
    {
        if (_onJSDrag)
        {
            Vector3 direction = _jsMovement.InputDirection;
            float angleJS = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            if (angleJS < 0.1) angleJS = 360 + angleJS;
            float angleShip = _ship.transform.rotation.eulerAngles.z;
            float thrust = direction.sqrMagnitude;
            _ship.ChangeThrust(thrust);
            if (angleShip < angleJS)
            {
                _ship.CalculateAngles(1, angleJS, angleShip);
            }
            else
            {
                _ship.CalculateAngles(-1, angleJS, angleShip);
            }
        }
    }
    private void Shoot(bool isShooting) 
    {
        _ship.Shoot(isShooting);
    }
    private void LaunchMissile() 
    {
        
    }
    private void Boost(bool isBoosting) 
    {
        _ship.IsBoosted = isBoosting;
    }
}