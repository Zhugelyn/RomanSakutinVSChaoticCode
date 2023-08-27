using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("MovementOn", true);
    }
}
