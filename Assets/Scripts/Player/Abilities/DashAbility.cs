
using UnityEngine;

public class DashAbility : Ability
{
    [SerializeField]
    private float dashSpeed = 20f;

    [SerializeField]
    private float dashDuration = 0.2f;

    [SerializeField]
    private float dashCooldown = 0.5f;

   private float timer;
   private float cooldown;

   private Vector2 direction;


    protected override void Awake()
    {
        base.Awake();

        cooldown = 0f;

        movement = GetComponent<MovementController>();

    }

    public float Duration => dashDuration;

    public override bool Finished()
    {
        return timer <= 0f;
    }
    


    public override bool CanActivate()
    {
        if (cooldown < 0.05f)
            return true;    
        else
            return false;
    }

    public override void Cooldown()
    {
        if (cooldown > 0.005f)
        {
            Debug.Log($"Dash Cooldown {cooldown}");
            cooldown -= Time.deltaTime;

        }
    }


    public override void Begin()
    {
        Debug.Log(" Dash ability triggered ");

        direction = GetComponent<InputHandler>().MoveInput;

        if (direction == Vector2.zero)
        {
            direction = Vector2.right;
        }

        timer = dashDuration;
        cooldown = dashCooldown;

        movement.StartDash(direction, dashSpeed);

    }

    public override void Tick()
    {
        timer -= Time.deltaTime;
    }
    
        public override void End()
    {
        Debug.Log("Dash end");
        movement.StopDash();
    }



}
