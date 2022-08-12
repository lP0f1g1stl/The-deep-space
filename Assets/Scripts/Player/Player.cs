using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player's objects")]
    [SerializeField] private Ship _playerShip;
    [SerializeField] private CameraControl _mainCameraControl;
    [Header("Handlers")]
    [SerializeField] private HealthUIHandler _healthUIHandler;
    [SerializeField] private PlayerControl _playerControl;

    private HealthLogic _playerHealth;

    private void Awake()
    {
        if (_playerShip != null)
        {
            SetShip();
        }
    }
    private void ChangeShip(Ship newPlayerShip) 
    {
        RemoveListeners();
        _playerShip = newPlayerShip;
        SetShip();
    }
    private void SetShip() 
    {
        _playerHealth = _playerShip.GetComponent<HealthLogic>();
        _playerControl.Ship = _playerShip;
        _mainCameraControl.SetNewShip(_playerShip.transform);
        AddListeners();
    }
    private void AddListeners()
    {
        _playerHealth.OnHealthChange += _healthUIHandler.ChangeHealth;
        _playerHealth.OnShieldChange += _healthUIHandler.ChangeShield;
    }
    private void RemoveListeners()
    {
        _playerHealth.OnHealthChange -= _healthUIHandler.ChangeHealth;
        _playerHealth.OnShieldChange -= _healthUIHandler.ChangeShield;
    }
    private void OnDisable()
    {
        RemoveListeners();
    }
}
