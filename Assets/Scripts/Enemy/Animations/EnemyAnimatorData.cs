using UnityEngine;

public static class EnemyAnimatorData
{
    public static class Params
    {
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Hit = Animator.StringToHash(nameof(Hit));
    }
}
