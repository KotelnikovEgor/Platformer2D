using UnityEngine;

[RequireComponent(typeof(EnemyVision))]
public class EnemyPersecutionState : MonoBehaviour, IExitableState, IEnterablePayloadState<ITransformPayload>
{
    private readonly float _speed = 3f;
    private readonly float _stopDistance = 0.5f;

    private Transform _player;
    private EnemyVision _enemyVision;
    private StateMachine _stateMachine;

    private void Start()
    {
        _enemyVision = GetComponent<EnemyVision>();
    }

    private void Update()
    {
        if (!_enemyVision.IsSeePlayer)
        {
            _stateMachine.ChangeState<EnemyPatrolState>();
            return;
        }

        if(_player != null)
            Move();
    }

    private void Move()
    {
        if ((transform.position - _player.position).sqrMagnitude > _stopDistance)
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }

    public void Enter(ITransformPayload payload)
    {
        _player = payload.Transform;
    }

    public void Exit()
    {
        _player = null;
    }

    public void SetStateMachine(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
