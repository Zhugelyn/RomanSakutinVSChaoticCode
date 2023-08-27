using System;
using UnityEngine;

public class DildoTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    public event Action<bool> OnDieSound;

    private int hp = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 3)
        {
            Destroy(collision.gameObject);
            _renderer.color = Color.red;
            Invoke("ResetColor", 0.2f);
            hp--;
        }

        if (hp == 0)
        {
            OnDieSound?.Invoke(true);
            Destroy(gameObject);

        }


        if (gameObject.layer == 6)
            Destroy(gameObject);
    }

    private void ResetColor()
    {
        _renderer.color = Color.white;
    }
}
