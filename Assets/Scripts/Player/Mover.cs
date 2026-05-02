using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private Vector3 _reqiredScale = new(0, 1, 1);

    public event Action Moving;
    public event Action Staying;

    private void Update()
    {
        if (_inputReader.Direction != 0)
        {
            Move();
            Flip();
            Moving?.Invoke();
        }
        else
        {
            Staying?.Invoke();
        }
    }

    private void Move()
    {
        Vector3 direction = Vector2.right * _inputReader.Direction;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void Flip()
    {
        transform.localScale = Vector3.right * _inputReader.Direction + _reqiredScale;
    }
}
