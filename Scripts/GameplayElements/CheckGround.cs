using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

	private bool _isGrounded;

    public bool UpdateGroundedStatus()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        return _isGrounded;
    }
}

