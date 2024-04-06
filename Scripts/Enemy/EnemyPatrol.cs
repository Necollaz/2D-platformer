using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _startWaitTime = 3f;
    [SerializeField] private EnemyDetector _enemyDetector;

    private EnemyAnimationController _animation;
    private ChasePlayer _chasePlayer;
    private EnemyMover _mover;
    private float _waitTime;
    private int _randomPoint;

    private void Start()
    {
        _randomPoint = Random.Range(0, _movePoints.Length);
        _waitTime = _startWaitTime;
        _animation = GetComponent<EnemyAnimationController>();
        _chasePlayer = GetComponent<ChasePlayer>();
        _mover = GetComponent<EnemyMover>();
        MoveAndRotate(_movePoints[_randomPoint]);
        _animation.Walk(true);
    }

    private void Update()
    {
        if (_enemyDetector.Player != null)
        {
            _chasePlayer.StartChasing(_enemyDetector.Player);
            _animation.Walk(true);
            Debug.Log("Игрок обнаружен");
        }
        else
        {
            _chasePlayer.StopChasing();
            Patrol();
            Debug.Log("Игрок не обнаружен");
        }
    }

    public void Patrol()
    {
        if (Vector2.Distance(transform.position, _movePoints[_randomPoint].position) < 0.2f)
        {
            _animation.Walk(false);

            if (_waitTime <= 0)
            {
                _randomPoint = (_randomPoint + 1) % _movePoints.Length;
                _waitTime = _startWaitTime;
                MoveAndRotate(_movePoints[_randomPoint]);
                _animation.Walk(true);
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
        else
        {
            MoveAndRotate(_movePoints[_randomPoint]);
            _animation.Walk(true);
        }
    }

    private void MoveAndRotate(Transform target)
    {
        _mover.MoveAndRotate(transform, target, _speed);
    }
}
