using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CheckGround), typeof(PlayerAnimation))]
public class PlayerMover : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private CheckGround _checkerGround;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _checkerGround = GetComponent<CheckGround>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        Move();
        Jump();
        _playerAnimation.UpdateAnimationState();
        _checkerGround.UpdateGroundedStatus();
    }

    private void Move()
    {
        float horizontlDirection = Input.GetAxis(HorizontalInput);

        if (horizontlDirection != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontlDirection), 1, 1);
            Vector2 movement = new Vector2(horizontlDirection, 0f) * _speed;
            _rigidbody2D.velocity = new Vector2(movement.x, _rigidbody2D.velocity.y);
            _playerAnimation.Walk(Mathf.Abs(horizontlDirection) > 0);
        }
        else
        {
            _playerAnimation.Walk(false);
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _checkerGround.UpdateGroundedStatus())
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _playerAnimation.Jump();
        }
    }
}
