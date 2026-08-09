using UnityEngine;

public class EnemyAnimationSwitcher
{
    private readonly Animator _animator;

    public EnemyAnimationSwitcher(Animator animator)
    {
        _animator = animator;
    }

    public void EnableAttack() => _animator.SetTrigger(EnemyAnimatorData.Params.Attack);
}
