using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealh;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealh;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealh)
        {
            return;
        }

        _currentHealth += amountToAdd;

        if (_currentHealth > _maximumHealh)
        {
            _currentHealth = _maximumHealh;
        }
    }
}