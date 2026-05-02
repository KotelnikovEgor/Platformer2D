using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Mover), typeof(Jumper))]
public class CharacterAnimation : MonoBehaviour
{
    private const string IsRun = nameof(IsRun);
    private const string IsJump = nameof(IsJump);

    private Mover _mover;
    private Jumper _jumper;
    private Animator _animator;

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _animator = GetComponent<Animator>();

        _mover.Moving += EnableRunParameter;
        _mover.Staying += DisableRunParameter;
        _jumper.Jumping += EnableJumpParameter;
        _jumper.Grounded += DisableJumpParameter;
    }

    private void OnDisable()
    {
        _mover.Moving -= EnableRunParameter;
        _mover.Staying -= DisableRunParameter;
        _jumper.Jumping -= EnableJumpParameter;
        _jumper.Grounded -= DisableJumpParameter;
    }

    private void EnableRunParameter()
    {
        _animator.SetBool(IsRun, true);
    }

    private void DisableRunParameter()
    {
        _animator.SetBool(IsRun, false);
    }

    private void EnableJumpParameter()
    {
        _animator.SetBool(IsJump, true);
    }

    private void DisableJumpParameter()
    {
        _animator.SetBool(IsJump, false);
    }
}
