
using UnityEngine;

public class SwordAbility : Ability
{
    [SerializeField]
    private Collider2D swordHitbox;

    [SerializeField]
    private float attackTime = 0.2f;

    private float timer;

     public override bool CanActivate()
    {
        return true;
    }

    public override void Begin()
    {
        timer = attackTime;
        swordHitbox.enabled = true;
        Debug.Log("Sword Triggered");
    }

    public override void Tick()
    {
        timer -= Time.deltaTime;
    }

    public override bool Finished()
    {
        return timer <= 0f;
    }

    public override void End()
    {
        swordHitbox.enabled = false;
        Debug.Log("Sword Ended");
    }



}
