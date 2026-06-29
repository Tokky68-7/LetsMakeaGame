
using UnityEngine;

public class DashAbility : Ability
{
    [SerializeField]
    private float dashSpeed = 20f;

    [SerializeField]
    private float dashDuration = 0.2f;

   private float timer;
   private Vector2 direction;


    protected override void Awake()
    {
        base.Awake();

        movement = GetComponent<MovementController>();

    }

    public float Duration => dashDuration;

    public override bool Finished()
    {
        return timer <= 0f;
    }
    


    public override bool CanActivate()
    {
        return true;
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

        movement.StartDash(direction, dashSpeed);

    }

    public override void Tick()
    {
        timer -= Time.deltaTime;
    }
    
    public bool Finsihed()
    {
        return timer <= 0f;
    }

        public override void End()
    {
        Debug.Log("Dash end");
        movement.StopDash();
    }



}
