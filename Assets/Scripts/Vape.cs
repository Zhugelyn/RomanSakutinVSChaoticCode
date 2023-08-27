using UnityEngine;

public class Vape : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            _playerHealth.Heal();
            Destroy(gameObject);
        }
    }
}
