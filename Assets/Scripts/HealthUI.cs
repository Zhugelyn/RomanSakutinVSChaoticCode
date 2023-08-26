using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;
    [SerializeField] private PlayerHealth _playerHealth;
    private void OnEnable()
    {
        _playerHealth.HealthChanged += _playerHealth_HealthChanged;
    }
    private void OnDisable()
    {
        _playerHealth.HealthChanged -= _playerHealth_HealthChanged;
    }

    private void _playerHealth_HealthChanged(int health, int maxHealth)
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < health)
            {
                _hearts[i].sprite = _fullHeartSprite;
            }
            else
            {
                _hearts[i].sprite = _emptyHeartSprite;
            }
            if (i < maxHealth)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }
}
