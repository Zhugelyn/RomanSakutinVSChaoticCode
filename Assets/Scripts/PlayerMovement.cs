using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private string MoveDeltaX = "MoveDeltaX";
    private string MoveDeltaY = "MoveDeltaY";
    private string IsVertical = "IsVertical";

    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private Animator _animator;

    private Vector3 _moveDelta;
    private bool _isFacingRight = true;

    private void Update()
    {
        float x = Input.GetAxis(HorizontalAxis);
        float y = Input.GetAxis(VerticalAxis);

        _moveDelta = new Vector3(x, y, 0f);

        transform.Translate(_moveDelta * _speed * Time.deltaTime);
        ToggleAnimation(_moveDelta);
        Flip(x);
    }

    private void ToggleAnimation(Vector3 moveDelta)
    {
        _animator.SetFloat(MoveDeltaX, moveDelta.x);
        _animator.SetFloat(MoveDeltaY, moveDelta.y);

        if (moveDelta.y > 0 || moveDelta.y < 0)
            _animator.SetBool(IsVertical, true);
        else
            _animator.SetBool(IsVertical, false);
    }
    private void Flip(float x)
    {
        if (_isFacingRight && x < 0f || !_isFacingRight && x > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
