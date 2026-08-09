using UnityEngine;

public class AttackState : BaseState, IEnterablePayloadState<PlayerPayload>, IUpdateState
{
    private readonly float _rate = 1f;
    private readonly int _damage = 20;
    private readonly float _persecutionEnterDistance = 1.5f;
    private readonly EnemyAnimationSwitcher _animationSwitcher;

    private float _attackCooldown;
    private Transform _player;

    public AttackState(IStateChanger stateChanger, Transform transform, EnemyVision vision, EnemyAnimationSwitcher animationSwitcher) : base(stateChanger, transform, vision)
    {
        _animationSwitcher = animationSwitcher;
    }

    public void Enter(PlayerPayload payload)
    {
        _player = payload.Transform;
        _attackCooldown = 0f;
    }

    public override void Exit()
    {
        _player = null;
    }

    public void Update()
    {
        if (!_vision.IsSeePlayer)
        {
            _stateMachine.ChangeState<PatrolState>();
            return;
        }

        if (_player != null)
        {
            float distance = Mathf.Abs(_transform.position.x - _player.position.x);

            if (distance >= _persecutionEnterDistance)
            {
                PlayerPayload payload = new(_player);
                _stateMachine.ChangeState<PersecutionState, PlayerPayload>(payload);
                return;
            }

            if (_attackCooldown > 0)
                _attackCooldown -= Time.deltaTime;

            if (_attackCooldown <= 0)
                Attack();
        }
    }

    private void Attack()
    {
        if (_player.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
            _animationSwitcher.EnableAttack();
            _attackCooldown = _rate;
        }
    }
}
