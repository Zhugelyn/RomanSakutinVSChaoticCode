using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterAnimationSwitcher _characterAnimationSwitcher;

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
        _characterAnimationSwitcher.ToggleWalkingAnimation(_moveDelta);
        _characterAnimationSwitcher.ToogleRunningAnimation(_moveDelta);
        _characterAnimationSwitcher.ToogleIdleAnimation(_moveDelta);
    }
}
