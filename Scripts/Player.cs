using System;
using System.Collections;
using UnityEngine;

public static class PlayerAnimationData
{
    public static class Params
    {
        public static readonly int Walk = Animator.StringToHash("isWalk");
        public static readonly int Jump = Animator.StringToHash("onGround");
        public static readonly int Attack = Animator.StringToHash("isAttack");
    }
}

public class Player : MonoBehaviour
{
    public event Action<int> CoinCountChanged;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool _canHit = true;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if(_rigidbody2D == null)
        {
            Debug.LogError("Rigidbode2D component not found" + gameObject.name);
        }

        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Animator component not found" + gameObject.name);
        }
    }

    private void Update()
    {
        Move();
        Jump();
        SetupAnimations();
        UpdateGroundedStatus();
    }

    private void UpdateGroundedStatus()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        _animator.SetBool("onGround", _isGrounded);
    }

    private void Move()
    {
        float horizontlDirection = Input.GetAxis("Horizontal");

        if(horizontlDirection != 0)
            transform.localScale = new Vector3(Mathf.Sign(horizontlDirection), 1, 1);

        Vector2 movement = new Vector2(horizontlDirection, 0f) * _speed;
        _rigidbody2D.velocity = new Vector2(movement.x, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }

    private void SetupAnimations()
    {
        _animator.SetBool(PlayerAnimationData.Params.Walk, _rigidbody2D.velocity.x != 0 && _isGrounded);
        _animator.SetBool(PlayerAnimationData.Params.Jump, !_isGrounded);

        if(Input.GetMouseButton(0) && _canHit)
        {
            _animator.SetTrigger(PlayerAnimationData.Params.Attack);
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        _canHit = false;
        yield return new WaitForSeconds(_reloadTime);
        _canHit = true;
    }

    private void OnCoinCollected(int newCoinCount)
    {
        CoinCountChanged?.Invoke(newCoinCount);
    }
}
