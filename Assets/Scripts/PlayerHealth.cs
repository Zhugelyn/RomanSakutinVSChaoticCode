using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioSource _audioSource;
    private int _maxHealth = 3;
    public event Action<int, int> HealthChanged;

    [ContextMenu(nameof(Heal))]
    public void Heal()
    {
        if( _health == _maxHealth )
            return;
        _health += 1;
        HealthChanged?.Invoke(_health, _maxHealth);
    }
    [ContextMenu(nameof(TakeDamage))]
    public void TakeDamage()
    {
        _health -= 1;
        HealthChanged?.Invoke(_health, _maxHealth);
        _audioSource.Play();
    }
}
