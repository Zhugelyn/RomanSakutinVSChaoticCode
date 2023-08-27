using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed = 2f;
    [SerializeField] private Transform _target;
    private float cameraHeight = -1f;


    private void LateUpdate()
    {
        Vector3 newPos = new Vector3(_target.position.x, _target.position.y, cameraHeight);
        transform.position = Vector3.Slerp(transform.position, newPos, _cameraSpeed);
    }
}
