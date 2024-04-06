using UnityEngine;

public static class EnemyAnimationData
{
    public static class Params
    {
        public static readonly int Walk = Animator.StringToHash("isWalk");
        public static readonly int Attack = Animator.StringToHash("isAttack");
    }
}

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk(bool isWalking)
    {
        _animator.SetBool(EnemyAnimationData.Params.Walk, isWalking);
    }

    public void Attack()
    {
        _animator.SetTrigger(EnemyAnimationData.Params.Attack);
    }
}
