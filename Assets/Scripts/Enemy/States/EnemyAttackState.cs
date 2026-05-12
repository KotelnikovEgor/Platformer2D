using UnityEngine;

public class EnemyAttackState : BaseState, IEnterablePayloadState<ITransformPayload>, IUpdateState
{
    private readonly float _rate = 1f;
    private readonly int _damage = 1;
    private readonly float _persecutionEnterDistance = 1.5f;
    private readonly EnemyAnimator _enemyAnimator;

    private float _attackCooldown;
    private Transform _player;

    public EnemyAttackState(EnemyAnimator enemyAnimation, EnemyVision enemyVision, Transform transform) : base(transform, enemyVision)
    {
        _enemyAnimator = enemyAnimation;
    }

    public void Enter(ITransformPayload payload)
    {
        _player = payload.Transform;
    }

    public override void Exit()
    {
        _player = null;
    }

    public void Update()
    {
        if (!_enemyVision.IsSeePlayer)
        {
            _stateMachine.ChangeState<EnemyPatrolState>();
            return;
        }

        if (_player != null)
        {
            float distance = (_transform.position - _player.position).sqrMagnitude;

            if (distance >= _persecutionEnterDistance)
            {
                var playerTransform = new PlayerPayload(_player);
                _stateMachine.ChangeState<EnemyPersecutionState, ITransformPayload>(playerTransform);
                return;
            }

            Attack();
        }
    }

    private void Attack()
    {
        if (_player.TryGetComponent(out IDamageable damageable))
        {
            _attackCooldown -= Time.deltaTime;

            if (_attackCooldown <= 0)
            {
                damageable.TakeDamage(_damage);
                _enemyAnimator.EnableAttackParameter();
                _attackCooldown = _rate;
            }
        }
    }
}
