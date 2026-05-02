using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Destroying;

    private void OnDestroy()
    {
        Destroying?.Invoke();
    }
}
