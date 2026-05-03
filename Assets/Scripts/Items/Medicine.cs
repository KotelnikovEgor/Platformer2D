using System;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public event Action Destroying;

    private void OnDestroy()
    {
        Destroying?.Invoke();
    }
}
