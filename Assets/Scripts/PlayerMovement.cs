using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    // Надо бы работу с анимациями в отделный класс пихнуть.
    private string _moveDeltaX = "MoveDeltaX";
    private string _moveDeltaY = "MoveDeltaY";
    private string _isHorizontal = "IsHorizontal";
    private string _isStanding = "IsStanding";
    private string _isRunning = "Running";
    private Vector3 _moveDelta;

    private void Update()
    {
        float x = Input.GetAxis(HorizontalAxis);
        float y = Input.GetAxis(VerticalAxis);

        _moveDelta = new Vector3(x, y, 0f);

        ToggleAnimation();
        transform.Translate(_moveDelta * _speed * Time.deltaTime);
    }

    private void ToggleAnimation()
    {
        ToggleWalkingAnimation();
        ToogleRunningAnimation();
        ToogleIdleAnimation();
    }

    public void ToggleWalkingAnimation()
    {
        _animator.SetFloat(_moveDeltaX, _moveDelta.x);
        _animator.SetFloat(_moveDeltaY, _moveDelta.y);

        if (_moveDelta.x != 0)
            _animator.SetBool(_isHorizontal, true);
        else
            _animator.SetBool(_isHorizontal, false);
    }

    public void ToogleRunningAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 2f;
            _animator.SetTrigger(_isRunning);
        }
    }

    public void ToogleIdleAnimation()
    {
        if (_moveDelta.x == 0 && _moveDelta.y == 0)
            _animator.SetBool(_isStanding, true);
        else
            _animator.SetBool(_isStanding, false);
    }
}
