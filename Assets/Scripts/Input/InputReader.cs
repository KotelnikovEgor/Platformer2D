using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    public event Action JumpPressed;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetButtonDown(Jump))
            JumpPressed?.Invoke();
    }
}
