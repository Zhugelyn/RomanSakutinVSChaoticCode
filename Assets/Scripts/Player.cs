using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _speed;

    private Vector3 _moveDelta;
    private void FixedUpdate()
    {
        float x = Input.GetAxis(HorizontalAxis);
        float y = Input.GetAxis(VerticalAxis);

        _moveDelta = new Vector3(x, y, 0f);

        if (_moveDelta.x > 0f)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0f)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.Translate(_moveDelta * _speed * Time.deltaTime);
    }
}
