using UnityEngine;

[RequireComponent(typeof(Fliper), typeof(Animation))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private Fliper _fliper;
    private Animation _playerAnimation;

    private void Start()
    {
        _fliper = GetComponent<Fliper>();
        _playerAnimation = GetComponent<Animation>();
    }

    private void Update()
    {
        if (_inputReader.Direction != 0)
        {
            Move();
            _fliper.Flip(_inputReader.Direction);
            _playerAnimation.EnableRunParameter();
        }
        else
        {
            _playerAnimation.DisableRunParameter();
        }
    }

    private void Move()
    {
        Vector3 direction = transform.right * _inputReader.Direction;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
