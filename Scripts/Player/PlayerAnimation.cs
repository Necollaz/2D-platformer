using UnityEngine;

public static class PlayerAnimationData
{
    public static class Params
    {
        public static readonly int Walk = Animator.StringToHash("isWalk");
        public static readonly int Jump = Animator.StringToHash("isJump");
        public static readonly int Attack = Animator.StringToHash("isAttack");
    }
}

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private CheckGround _checkGround;
    private bool _isJumping = false;
 
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _checkGround = GetComponent<CheckGround>();
    }

    public void Walk(bool isWalking)
    {
        if(!_isJumping)
            _animator.SetBool(PlayerAnimationData.Params.Walk, isWalking && _checkGround.UpdateGroundedStatus());
    }

    public void Jump()
    {
        _isJumping = true;
        _animator.SetBool(PlayerAnimationData.Params.Jump, true);
    }

    public void UpdateAnimationState()
    {
        bool isGrounded = _checkGround.UpdateGroundedStatus();
        Debug.Log($"Is Grounded: {isGrounded}, Is Jumping: {_isJumping}");

        if (isGrounded && _isJumping)
        {
            _isJumping = false;
            _animator.SetBool(PlayerAnimationData.Params.Jump, false);
            Debug.Log("Landed!");
        }
    }
}
