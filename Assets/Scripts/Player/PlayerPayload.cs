using UnityEngine;

public class PlayerPayload : ITransformPayload
{
    public Transform Transform { get; private set; }

    public PlayerPayload(Transform player)
    {
        Transform = player;
    }
}
