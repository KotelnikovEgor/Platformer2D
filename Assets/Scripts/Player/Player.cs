using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private LayerMask _levelLayer;
    [SerializeField] private PlayerMovementInitializer _playerMovementInitializer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Health _health;
    [SerializeField] private SmoothHealthBar _smoothHealthBar;
    [SerializeField] private SmoothHealthBar _smoothVampirismBar;
    [SerializeField] private GameObject _vampirismVisualizer;

    private CollisionDetector _collisionDetector;
    private PlayerMovement _movement;
    private PlayerAnimationSwitcher _animationSwitcher;
    private Vampirism _vampirism;
    private Attacker _attacker;
    private PlayerDeath _playerDeath;

    private void Update()
    {
        _movement.UpdateVelocity();
        _animationSwitcher.UpdateMovementAnimations(_movement.Velocity);
        _vampirism.Update();
    }

    private void FixedUpdate()
    {
        _movement.ApplyPhysics();
        _collisionDetector.Detect();
    }

    private void OnDestroy()
    {
        _attacker.Dispose();
        _playerDeath.Dispose();
        _vampirism.Dispose();
    }

    public void Construct(InputReader inputReader)
    {
        _collisionDetector = new(_collider, _levelLayer);
        _movement = _playerMovementInitializer.Create(_rigidbody, transform, inputReader, inputReader, _collisionDetector);
        _animationSwitcher = new(_animator);
        _vampirism = new(transform, _enemyLayer, _health, inputReader, _vampirismVisualizer);
        _attacker = new(inputReader, transform, _enemyLayer, _animationSwitcher);
        _playerDeath = new(_health, transform.position, transform);
        _smoothHealthBar.Construct(_health);
        _smoothVampirismBar.Construct(_vampirism);
    }
}
