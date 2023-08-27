using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _moveDeltaX = "MoveDeltaX";
    private string _moveDeltaY = "MoveDeltaY";
    private string _isHorizontal = "IsHorizontal";
    private string _isStanding = "IsStanding";
    private string _isRunning = "Running";

    public void ToggleWalkingAnimation(Vector3 _moveDelta)
    {
        _animator.SetFloat(_moveDeltaX, _moveDelta.x);
        _animator.SetFloat(_moveDeltaY, _moveDelta.y);

        if (_moveDelta.x != 0)
            _animator.SetBool(_isHorizontal, true);
        else
            _animator.SetBool(_isHorizontal, false);
    }

    public void ToogleRunningAnimation(Vector3 _moveDelta)
    {
        _animator.SetTrigger(_isRunning);
    }

    public void ToogleIdleAnimation(Vector3 _moveDelta)
    {
        if (_moveDelta.x == 0 && _moveDelta.y == 0)
            _animator.SetBool(_isStanding, true);
        else
            _animator.SetBool(_isStanding, false);
    }
}
