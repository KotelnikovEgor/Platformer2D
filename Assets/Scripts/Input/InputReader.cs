using System;
using UnityEngine;

public class InputReader : MonoBehaviour, IDirectionProvider, IJumpProvider
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    private const string Fire1 = nameof(Fire1);

    public event Action FirePressed;

    public float Direction { get; private set; }

    public bool IsJumpPressed { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);
        IsJumpPressed = Input.GetButtonDown(Jump);

        if (Input.GetButtonDown(Fire1))
            FirePressed?.Invoke();
    }
}
