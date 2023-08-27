using UnityEngine;
using System;

public class HowdyHoSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceDie;
    [SerializeField] private DildoTrigger _damageTrigger;

    private void OnEnable()
    {
        _damageTrigger.OnDieSound += _damageTrigger_OnDieSound;
    }

    private void OnDisable()
    {
        _damageTrigger.OnDieSound -= _damageTrigger_OnDieSound;
    }
    private void _damageTrigger_OnDieSound(bool obj)
    {
        _audioSourceDie.Play();
    }
}
