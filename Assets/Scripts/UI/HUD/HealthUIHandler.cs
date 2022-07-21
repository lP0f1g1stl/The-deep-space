using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIHandler : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _shieldBar;

    public void ChangeHealth(int curentHealth, int maxHealth) 
    {
        _healthBar.fillAmount = (float)curentHealth / maxHealth;
    }
    public void ChangeShield(int currentShield, int maxShield)
    {
        _shieldBar.fillAmount = (float)currentShield / maxShield;
    }
}
