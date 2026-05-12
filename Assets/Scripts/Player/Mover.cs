using UnityEngine;

[RequireComponent(typeof(Fliper), typeof(PlayerAnimator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private Fliper _fliper;
    private PlayerAnimator _playerAnimator;

    private void Start()
    {
        _fliper = GetComponent<Fliper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        if (_inputReader.Direction != 0)
        {
            Move();
            _fliper.Flip(_inputReader.Direction);
            _playerAnimator.EnableRunParameter();
        }
        else
        {
            _playerAnimator.DisableRunParameter();
        }
    }

    private void Move()
    {
        Vector3 direction = transform.right * _inputReader.Direction;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
