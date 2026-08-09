using UnityEngine;

public class PlayerPayload : IPayload
{
    public Transform Transform { get; private set; }

    public PlayerPayload(Transform player)
    {
        Transform = player;
    }
}
