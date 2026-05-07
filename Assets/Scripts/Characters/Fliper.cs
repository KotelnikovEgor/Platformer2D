using UnityEngine;

public class Fliper : MonoBehaviour
{
    private Vector3 _right = new(0, 0, 0);
    private Vector3 _left = new(0, 180, 0);

    public void Flip(float direction)
    {
        if (direction > 0)
            transform.rotation = Quaternion.Euler(_right);
        else if (direction < 0)
            transform.rotation = Quaternion.Euler(_left);
    }
}
