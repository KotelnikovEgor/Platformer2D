using System;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public int Treatment { get; private set; } = 1;

    public event Action Collected;

    public void Collect()
    {
        Collected?.Invoke();
    }
}
