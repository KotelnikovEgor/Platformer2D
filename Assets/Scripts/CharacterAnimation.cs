using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Jump))]
public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundCheck _groundCheck;

    private const string IsRun = nameof(IsRun);
    private const string IsJump = nameof(IsJump);

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsRun, _inputReader.Direction != 0);
        _animator.SetBool(IsJump, !_groundCheck.IsGrounded);
    }
}
