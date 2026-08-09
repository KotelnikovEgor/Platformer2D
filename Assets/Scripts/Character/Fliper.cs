using UnityEngine;

public class Fliper
{
    private readonly Transform _transform;
    private readonly Quaternion _right = Quaternion.Euler(0, 0, 0);
    private readonly Quaternion _left = Quaternion.Euler(0, 180, 0);

    public Fliper(Transform transform)
    {
        _transform = transform;
    }

    public void Flip(float xDirection)
    {
        if (xDirection == 0)
            return;

        if (xDirection > 0)
            _transform.rotation = _right;
        else if (xDirection < 0)
            _transform.rotation = _left;
    }
}
