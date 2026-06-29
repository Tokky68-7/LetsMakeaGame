using UnityEngine;

public struct DamageInfo
{
    public float Damage { get; }
    public Vector2 Direction { get; }

    public float Knockback {get; }
    public GameObject Source { get; }

    public DamageInfo(
        float damage,
        Vector2 direction,
        float knockback,
        GameObject source)
    {
        Damage = damage;
        Direction = direction;
        Knockback = knockback;
        Source = source;
    }
    
}
