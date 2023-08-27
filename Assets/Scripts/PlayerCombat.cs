using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayers;

    [SerializeField] private Animation _attackDildo;
    [SerializeField] private Transform _spawnDildo;
    [SerializeField] private GameObject _dildo;

    [SerializeField] private List<Transform> _spawnMentors;
    [SerializeField] private GameObject _mentor;
    [SerializeField] private Transform _targetPosition;
 
    private Vector2 _moveDelta;

    private void Update()
    {
        _moveDelta.x = Input.GetAxisRaw("Horizontal");
        _moveDelta.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
            Attack();

        if (Input.GetKeyDown(KeyCode.Space))
            AttackDildo();

        if (Input.GetKeyDown(KeyCode.F))
            CallOnMentors();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            //Здесь когда враги будут сделаем
        }
    }

    private void CallOnMentors()
    {
        for (int x = 0; x < 5; x++)
        {
            var mentor = Instantiate(_mentor, _spawnMentors[x]);
        }
    }

    private void AttackDildo()
    {
        var dildo = Instantiate(_dildo, _spawnDildo);
        dildo.GetComponent<Rigidbody2D>().AddForce(_moveDelta.normalized * 60f);
        dildo.GetComponent<Animation>().Blend("DildoAttack");
    }
}
