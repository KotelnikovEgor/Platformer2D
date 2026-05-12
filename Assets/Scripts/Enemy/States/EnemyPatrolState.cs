using UnityEngine;

public class EnemyPatrolState : BaseState, IEnterableState, IUpdateState
{
    private readonly float _speed = 2f;
    private readonly Fliper _fliper;
    private readonly Transform[] _targetPoints;

    private int _currentPoint = 0;

    public EnemyPatrolState(Fliper fliper, EnemyVision enemyVision, Transform transform, Transform[] targetPoints) : base(transform, enemyVision)
    {
        _fliper = fliper;
        _targetPoints = targetPoints;
    }

    public void Enter()
    {

    }

    public override void Exit()
    {
        
    }

    public void Update()
    {
        if (_enemyVision.IsSeePlayer)
        {
            var visibleTransform = new PlayerPayload(_enemyVision.Player);
            _stateMachine.ChangeState<EnemyPersecutionState, ITransformPayload>(visibleTransform);
        }

        Move();
    }

    private void Move()
    {
        float direction = _targetPoints[_currentPoint].position.x - _transform.position.x;
        _fliper.Flip(direction);

        _transform.position = Vector3.MoveTowards(_transform.position, _targetPoints[_currentPoint].position, _speed * Time.deltaTime);

        if (_transform.position == _targetPoints[_currentPoint].position)
            _currentPoint = (_currentPoint + 1) % _targetPoints.Length;
    }
}
