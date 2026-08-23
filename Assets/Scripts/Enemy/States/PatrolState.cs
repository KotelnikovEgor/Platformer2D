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
        if (Vision.IsSeePlayer)
        {
            PlayerPayload payload = new(Vision.Player);
            StateMachine.ChangeState<PersecutionState, PlayerPayload>(payload);
            return;
        }

        Move();
    }

    private void Move()
    {
        float direction = _targetPoints[_currentPoint].x - Transform.position.x;
        _fliper.Flip(direction);

        Transform.position = Vector3.MoveTowards(Transform.position, _targetPoints[_currentPoint], _speed * Time.deltaTime);

        if (Transform.position == _targetPoints[_currentPoint])
            _currentPoint = (_currentPoint + 1) % _targetPoints.Length;
    }
}
