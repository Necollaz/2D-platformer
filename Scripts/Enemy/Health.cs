using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthImproving = 20;

    private int _minHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }

    public event Action CharecterDied;
    public event Action HealthChanged;

    private void Awake()
    {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, _minHealth, MaxHealth);
        HealthChanged?.Invoke();

        if(CurrentHealth <= _minHealth)
        {
            CharecterDied?.Invoke();
        }
    }

    public void Heal()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _healthImproving, 0, MaxHealth);
        HealthChanged?.Invoke();
    }
}
