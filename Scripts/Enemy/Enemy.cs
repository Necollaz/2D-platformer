using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackRadius = 1f;
    [SerializeField] private float _detectionRadius = 3f;

    private Transform _player;
    private PlayerFinder _finder;
    private EnemyAnimaton _animation;
    private EnemyPatrol _patrol;
    private bool _isChasing = false;

    private void Awake()
    {
        _animation = GetComponent<EnemyAnimaton>();
        _patrol = GetComponent<EnemyPatrol>();
        _finder = GetComponent<PlayerFinder>();
    }

    private void Update()
    {
        if (_finder.Player == null) return;
        _player = _finder.Player.transform;

        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer < _detectionRadius)
            StartChasing();
        else if (_isChasing && distanceToPlayer >= _detectionRadius)
            StopChasing();

        if (_isChasing)
            ChasePlayer();
        else
            _patrol.PerformPatrol();
    }

    private void ChasePlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer <= _attackRadius)
        {
            _animation.Attack();
        }
        else
        {
            _patrol.PerformMoveAndRotate(_player);
            _animation.Walk(true);
        }
    }

    private void StartChasing()
    {
        _isChasing = true;
        _animation.Walk(true);
    }

    private void StopChasing()
    {
        _isChasing = false;
    }
}
