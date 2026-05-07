using UnityEngine;

[RequireComponent(typeof(Fliper), typeof(EnemyVision))]
public class EnemyPatrolState : MonoBehaviour, IExitableState, IEnterableState
{
    [SerializeField] private Transform[] _targetPoints;

    private readonly float _speed = 2f;

    private int _currentPoint = 0;
    private Fliper _fliper;
    private EnemyVision _enemyVision;
    private StateMachine _stateMachine;

    private void Start()
    {
        _fliper = GetComponent<Fliper>();
        _enemyVision = GetComponent<EnemyVision>();
    }

    private void Update()
    {
        if (_enemyVision.IsSeePlayer)
        {
            var visibleTransform = new PlayerPayload(_enemyVision.Player);
            _stateMachine.ChangeState<EnemyPersecutionState, ITransformPayload>(visibleTransform);
            return;
        }

        Move();
    }

    private void Move()
    {
        float direction = _targetPoints[_currentPoint].position.x - transform.position.x;
        _fliper.Flip(direction);

        transform.position = Vector3.MoveTowards(transform.position, _targetPoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _targetPoints[_currentPoint].position)
            _currentPoint = (_currentPoint + 1) % _targetPoints.Length;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void SetStateMachine(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
