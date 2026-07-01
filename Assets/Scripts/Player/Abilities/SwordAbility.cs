
using Unity.VisualScripting;
using UnityEngine;

public class SwordAbility : Ability
{
    [SerializeField]
    private Collider2D swordHitbox;

    [SerializeField]
    private float attackTime = 0.2f;

    [SerializeField]
    private float attackCooldown = 0.6f;



    private float timer;
    private float cooldown;

    protected override void Awake()
    {
        cooldown = 0f;
    }


     public override bool CanActivate()
    {
        if (cooldown < 0.05f)
        return true;
        else
        return false;
    }

    public override void Begin()
    {
        timer = attackTime;
        swordHitbox.enabled = true;
        Debug.Log("Sword Triggered");
        cooldown = attackCooldown;
    }

    public override void Tick()
    {
        timer -= Time.deltaTime;
    }

    public override void Cooldown()
    {
        if (cooldown > 0.005f)
        {
        Debug.Log($"Sword Cooldown {cooldown}");
        cooldown -= Time.deltaTime;
        }
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
