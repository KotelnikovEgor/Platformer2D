using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnableRunParameter()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, true);
    }

    public void DisableRunParameter()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, false);
    }

    public void EnableJumpParameter()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsJump, true);
    }

    public void DisableJumpParameter()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsJump, false);
    }

    public void EnableAttackParameter()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
    }
}
