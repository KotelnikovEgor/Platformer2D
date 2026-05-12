using UnityEngine;

public class EnemyPersecutionState : BaseState, IEnterablePayloadState<ITransformPayload>, IUpdateState
{
    private readonly float _speed = 3f;
    private readonly float _attackEnterDistance = 1f;

    private Transform _player;

    public EnemyPersecutionState(EnemyVision enemyVision, Transform transform) : base(transform, enemyVision) { }

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

            if (distance <= _attackEnterDistance)
            {
                var playerTransform = new PlayerPayload(_player);
                _stateMachine.ChangeState<EnemyAttackState, ITransformPayload>(playerTransform);
                return;
            }

            Move();
        }
    }

    private void Move()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _player.position, _speed * Time.deltaTime);
    }
}
