using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAnimationController))]
public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _attackRange;

    private EnemyMover _mover;
    private EnemyAnimationController _animation;
    private Transform _playerTransform;
    private bool _isChasing;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _animation = GetComponent<EnemyAnimationController>();
    }

    private void Update()
    {
        if (_isChasing && _playerTransform != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);

            if(distanceToPlayer <= _attackRange)
            {
                _animation.Walk(false);
                _animation.Attack();
            }
            else
            {
                _mover.MoveAndRotate(transform, _playerTransform, _chaseSpeed);
                _animation.Walk(true);
            }
        }
    }

    public void StartChasing(PlayerMover player)
    {
        _playerTransform = player.transform;
        _isChasing = true;
        _animation.Walk(true);
    }

    public void StopChasing()
    {
        _playerTransform = null;
        _isChasing = false;
        _animation.Walk(false);
    }
}

