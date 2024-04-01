using UnityEngine;

[RequireComponent(typeof(EnemyAnimaton))]
public class Patrol1 : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private PlayerFinder _seachPlayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTimeAtPoint;

    private EnemyAnimaton _enemyAnimaton;
    //private EnemyMover _enemyMover;
    private float _minDistanceContact = 0.5f;
    private int _currentPoint = 0;
    private float _waitTime;
    private bool _isWaiting = false;

    private void Awake()
    {
        _enemyAnimaton = GetComponent<EnemyAnimaton>();
        //_enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
       // float distanceToPlayer = Vector2.Distance(transform.position, _seachPlayer.Player.transform.position);

        //if (distanceToPlayer <= _seachPlayer.AttackRadius)
        {
            //_enemyAnimaton.Attack();
        }
       // else
        {
            PatrolArea();
           // _enemyAnimaton.Walk(true);
        }
    }

    private void PatrolArea()
    {
        if (!_isWaiting && Vector3.Distance(transform.position, _movePoints[_currentPoint].position) < _minDistanceContact)
        {
            _isWaiting = true;
            _waitTime = _waitTimeAtPoint;
           // _enemyAnimaton.Walk(false);
        }

        if (_isWaiting)
        {
            _waitTime -= Time.deltaTime;

            if(_waitTime <= 0f)
            {
                _isWaiting = false;
                _currentPoint = (_currentPoint + 1) % _movePoints.Length;
            }
        }
        else
        {
            //_enemyAnimaton.Walk(true);
           // _enemyMover.Move(_movePoints[_currentPoint].position, _speed);
        }
    }
}
