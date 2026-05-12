using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField] private Fliper _fliper;

    private StateMachine _stateMachine;

    public EnemyAnimator EnemyAnimation => _enemyAnimator;
    public EnemyVision EnemyVision => _enemyVision;
    public Fliper Fliper => _fliper;

    private void Update()
    {
        _stateMachine.UpdateState();
    }

    public void Construct(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
