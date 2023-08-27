using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _moveDelta;

    private void Update()
    {
        _moveDelta.x = Input.GetAxisRaw(HorizontalAxis);
        _moveDelta.y = Input.GetAxisRaw(VerticalAxis);

        Walk();
        transform.Translate(_moveDelta * _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDelta * _speed * Time.deltaTime);

        
    }

    private void Walk()
    {
        _animator.SetFloat(HorizontalAxis, _moveDelta.x);
        _animator.SetFloat(VerticalAxis, _moveDelta.y);
        _animator.SetFloat("Speed", _moveDelta.sqrMagnitude);
        Debug.Log(_moveDelta.sqrMagnitude);
    }
}
