using UnityEngine;

public class PatrolState : BaseState, IEnterableState, IUpdateState
{
    private readonly Fliper _fliper;
    private readonly Vector3[] _targetPoints;
    private readonly float _speed = 3f;

    private int _currentPoint = 0;

    public PatrolState(IStateChanger stateChanger, Transform transform, EnemyVision vision, Vector3[] targetPoints, Fliper fliper) : base(stateChanger, transform, vision)
    {
        _targetPoints = targetPoints;
        _fliper = fliper;
    }

    public void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public void Update()
    {
        if (_vision.IsSeePlayer)
        {
            PlayerPayload payload = new(_vision.Player);
            _stateMachine.ChangeState<PersecutionState, PlayerPayload>(payload);
            return;
        }

        Move();
    }

    private void Move()
    {
        float direction = _targetPoints[_currentPoint].x - _transform.position.x;
        _fliper.Flip(direction);

        _transform.position = Vector3.MoveTowards(_transform.position, _targetPoints[_currentPoint], _speed * Time.deltaTime);

        if (_transform.position == _targetPoints[_currentPoint])
            _currentPoint = (_currentPoint + 1) % _targetPoints.Length;
    }
}
