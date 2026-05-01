using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private Vector3 _reqiredScale = new(0, 1, 1);

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        Vector3 direction = Vector2.right * _inputReader.Direction;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void Flip()
    {
        if(_inputReader.Direction != 0)
            transform.localScale = Vector3.right * _inputReader.Direction + _reqiredScale;
    }
}
