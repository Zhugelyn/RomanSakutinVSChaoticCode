using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _playerHealth.TakeDamage();
        }
    }
}
