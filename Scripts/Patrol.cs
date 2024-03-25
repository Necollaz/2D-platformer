using UnityEngine;

public static class EnemyAnimationData
{
    public static class Params
    {
        public static readonly int Walk = Animator.StringToHash("isWalk");
        public static readonly int Attack = Animator.StringToHash("isAttack");
    }
}

public class Patrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;

    [Header("Patrol Settings")]
    [SerializeField] private float _startWaitTime;
    [SerializeField] private bool _isPatroling = true;

    [Header("Enemy Detection")]
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _detectionRadius;

    private Transform _player;
    private Animator _animator;
    private float _waitTime;
    private bool _isChasing = false;
    private int _randomPoint;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _randomPoint = Random.Range(0, _movePoints.Length);
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if(distanceToPlayer < _detectionRadius)
            StartChasing();
        else if(_isChasing && distanceToPlayer >= _detectionRadius)
            StopChasing();

        if (_isChasing)
            ChasePlayer();
        else
            PatrolArea();
    }

    private void MoveAndRotate(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        var direction = (target.position - transform.position).normalized;

        if (direction.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if(direction.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }

    private void PatrolArea()
    {
        MoveAndRotate(_movePoints[_randomPoint]);

        if (Vector2.Distance(transform.position, _movePoints[_randomPoint].position) < 0.2f)
        {
            if(_waitTime <= 0)
            {
                _randomPoint = Random.Range(0, _movePoints.Length);
                _waitTime = _startWaitTime;
                _animator.SetBool(EnemyAnimationData.Params.Walk, true);
            }
            else
            {
                _waitTime -= Time.deltaTime;
                _animator.SetBool(EnemyAnimationData.Params.Walk, false);
            }
        }
        else
            _animator.SetBool(EnemyAnimationData.Params.Walk, true);
    }

    private void Attack()
    {
        _animator.SetTrigger(EnemyAnimationData.Params.Attack);
    }

    private void ChasePlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if(distanceToPlayer <= _attackRadius)
            Attack();
        else
        {
            MoveAndRotate(_player);
            _animator.SetBool(EnemyAnimationData.Params.Walk, true);
        }
    }

    private void StartChasing()
    {
        _isChasing = true;
        _animator.SetBool(EnemyAnimationData.Params.Walk, true);
    }

    private void StopChasing()
    {
        _isChasing = false;
    }
}
