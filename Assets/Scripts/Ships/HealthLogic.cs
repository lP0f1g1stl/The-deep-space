using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthLogic : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _currentHealthPoints;
    [SerializeField] private int _maxHealthPoints;
    [SerializeField] private int _healthRegeneration;
    [Header("Shield")]
    [SerializeField] private int _currentShieldPoints;
    [SerializeField] private int _maxShieldPoints;
    [SerializeField] private int _shieldRegeneration;
    [Header("Regeneration Delay")]
    [SerializeField] private float timer = 1;

    private bool _regenerationIsStarted;

    public event Action<int, int> OnHealthChange;
    public event Action<int, int> OnShieldChange;

    public void SetData(int maxHealthPoints, int healthRegeneration, int maxShieldPoints, int shieldRegeneration) 
    {
        _maxHealthPoints = maxHealthPoints;
        _currentHealthPoints = maxHealthPoints;
        _healthRegeneration = healthRegeneration;
        _maxShieldPoints = maxShieldPoints;
        _currentShieldPoints = maxShieldPoints;
        _shieldRegeneration = shieldRegeneration;
    }
    public void ReciveDamage(int damage) 
    {
        if (_currentShieldPoints >= damage)
        {
            _currentShieldPoints -= damage;
            OnShieldChange?.Invoke(_currentShieldPoints, _maxShieldPoints);
        }
        else
        {
            _currentHealthPoints -= damage;
            OnHealthChange?.Invoke(_currentHealthPoints, _maxHealthPoints);
        }
        if (_currentHealthPoints <= 0) 
        {
            StopRegeneration();
            DeactivateShip();
        }
        if (_regenerationIsStarted == false && gameObject.activeSelf)
        {
            _regenerationIsStarted = true;
            StartCoroutine(RegenerationTimer());
        }
    }
    private IEnumerator RegenerationTimer() 
    {
        while (_regenerationIsStarted)
        {
            if (_currentShieldPoints < _maxShieldPoints)
            {
                _currentShieldPoints = Regenerate(_currentShieldPoints, _maxShieldPoints, _shieldRegeneration);
                OnShieldChange?.Invoke(_currentShieldPoints, _maxShieldPoints);
            }
            if (_currentHealthPoints < _maxHealthPoints)
            {
                _currentHealthPoints = Regenerate(_currentHealthPoints, _maxHealthPoints, _healthRegeneration);
                OnHealthChange?.Invoke(_currentHealthPoints, _maxHealthPoints);
            }
            yield return new WaitForSeconds(timer);
            if ((_healthRegeneration == 0 || _currentHealthPoints == _maxHealthPoints) && _currentShieldPoints == _maxShieldPoints)
            {
                StopRegeneration();
            }
        }
    }
    private int Regenerate(int curValue, int maxValue, int regenerationValue) 
    {
        if (maxValue - curValue >= regenerationValue)
        {
            curValue += regenerationValue;
        }
        else
        {
            curValue = maxValue;
        }
        return curValue;
    }
    private void StopRegeneration() 
    {
        _regenerationIsStarted = false;
    }
    private void DeactivateShip() 
    {
        gameObject.SetActive(false);
    }

}
