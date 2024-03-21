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
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _startWaitTime;
    [SerializeField] private bool _isPatroling = true;

    private Animator _animator;
    private float _waitTime;
    private int _randomPoint;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _randomPoint = Random.Range(0, _movePoints.Length);
        _waitTime = _startWaitTime;
    }

    private void Update()
    {
        if (_isPatroling)
        {
            MoveAndRotate();

            if(Vector2.Distance(transform.position, _movePoints[_randomPoint].position) < 0.2f)
            {
                _animator.SetBool(EnemyAnimationData.Params.Walk, false);

                if(_waitTime <= 0)
                {
                    _randomPoint = Random.Range(0, _movePoints.Length);
                    _waitTime = _startWaitTime;
                    _animator.SetBool(EnemyAnimationData.Params.Walk, true);
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
        }
    }

    private void MoveAndRotate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoints[_randomPoint].position, _speed * Time.deltaTime);

        var direction = (_movePoints[_randomPoint].position - transform.position).normalized;

        if (direction.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if(direction.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }
}
