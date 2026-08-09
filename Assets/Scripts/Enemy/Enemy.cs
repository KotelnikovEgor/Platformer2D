using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private Vector3[] _targetPoints;
    [SerializeField] private Health _health;

    private IStateMachineUpdater _stateMachine;
    private EnemyDeath _enemyDeath;

    private void Update()
    {
        _stateMachine.UpdateState();
    }

    private void OnDestroy()
    {
        _enemyDeath.Dispose();
    }

    public void Construct()
    {
        Fliper fliper = new(transform);
        EnemyAnimationSwitcher animationSwitcher = new(_animator);
        EnemyStateMachineFactory stateMachineFactory = new(animationSwitcher, _vision, transform, _targetPoints, fliper);
        _stateMachine = stateMachineFactory.Create();
        _enemyDeath = new(_health, gameObject);
    }
}
