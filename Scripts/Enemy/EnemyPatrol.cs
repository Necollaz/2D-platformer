using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _startWaitTime;

    private Transform _chaseTarget;
    private EnemyAnimaton _animation;
    private float _waitTime;
    private int _randomPoint;

    private void Awake()
    {
        _animation = GetComponent<EnemyAnimaton>();
        _randomPoint = Random.Range(0, _movePoints.Length);
    }

    private void Update()
    {
        PatrolArea();
    }

    public void PerformPatrol()
    {
        PatrolArea();
    }

    public void PerformMoveAndRotate(Transform target)
    {
        _chaseTarget = target;
        MoveAndRotate(_chaseTarget);
    }

    private void PatrolArea()
    {
        MoveAndRotate(_movePoints[_randomPoint]);

        if (Vector2.Distance(transform.position, _movePoints[_randomPoint].position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomPoint = Random.Range(0, _movePoints.Length);
                _waitTime = _startWaitTime;
                _animation.Walk(true);
            }
            else
            {
                _waitTime -= Time.deltaTime;
                _animation.Walk(false);
            }
        }
        else
        {
            _animation.Walk(true);
        }
    }

    private void MoveAndRotate(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        var direction = (target.position - transform.position).normalized;

        if (direction.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
