using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Player _player;

    private Transform _target;

    private void Start()
    {
        _target = _player.transform;
    }

    private void Update()
    {
        Vector2 targetPosition = new Vector2(_target.position.x, transform.position.y) + _offset;
        Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
