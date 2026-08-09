using UnityEngine;

public class PlayerAnimationSwitcher
{
    private readonly Animator _animator;

    public PlayerAnimationSwitcher(Animator animator)
    {
        _animator = animator;
    }

    public void UpdateMovementAnimations(Vector2 velocity)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, velocity.x != 0f);
        _animator.SetBool(PlayerAnimatorData.Params.IsJump, velocity.y > 0f);
        _animator.SetBool(PlayerAnimatorData.Params.IsFall, velocity.y < 0f);
    }

    public void EnableAttack() => _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
}
