using UnityEngine;

public class PersecutionState : BaseState, IEnterablePayloadState<PlayerPayload>, IUpdateState
{
    private readonly float _speed = 5f;
    private readonly float _attackEnterDistance = 1f;

    private Transform _player;

    public PersecutionState(IStateChanger stateChanger, Transform transform, EnemyVision vision) : base(stateChanger, transform, vision) { }

    public void Enter(PlayerPayload payload)
    {
        _player = payload.Transform;
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

            if (distance <= _attackEnterDistance)
            {
                PlayerPayload payload = new(_player);
                _stateMachine.ChangeState<AttackState, PlayerPayload>(payload);
                return;
            }

            Move();
        }
    }

    private void Move()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _player.position, _speed *  Time.deltaTime);
    }
}
