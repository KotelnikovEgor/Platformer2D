using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _speed;

    private readonly int _scaleChanger = 1;

    private int _currentPoint = 0;
    private Vector3 _reqiredScale = new(0, 1, 1);

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _targetPoints[_currentPoint].position)
            _currentPoint = (_currentPoint + 1) % _targetPoints.Length;
    }

    private void Flip()
    {
        if (transform.position.x > _targetPoints[_currentPoint].position.x)
            transform.localScale = Vector3.right * -_scaleChanger + _reqiredScale;
        else
            transform.localScale = Vector3.right * _scaleChanger + _reqiredScale;
    }
}
