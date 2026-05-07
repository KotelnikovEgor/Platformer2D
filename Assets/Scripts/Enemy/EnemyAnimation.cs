using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnableAttackParameter()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.Attack);
    }
}
