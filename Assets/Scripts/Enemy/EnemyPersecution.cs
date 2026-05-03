using UnityEngine;

public class EnemyPersecution : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private readonly int _scaleChanger = 1;
    private readonly float _stopDistance = 0.5f;

    private Vector3 _reqiredScale = new(0, 1, 1);

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        if ((transform.position -  _player.position).sqrMagnitude > _stopDistance)
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > _player.position.x)
            transform.localScale = Vector3.right * -_scaleChanger + _reqiredScale;
        else
            transform.localScale = Vector3.right * _scaleChanger + _reqiredScale;
    }
}
