using Unity.VisualScripting;
using UnityEngine;

public class DashingState : PlayerState
{
    public DashingState(PlayerStateMachine machine)
        : base(machine)
    {

    }

    private float timer;
    public float timer_max = 0.2f;

    private Vector2 dashDirection;



    public override void Enter()
    {
        Debug.Log("Entered Dashing");

        timer = timer_max;

        dashDirection =
            stateMachine.Input.MoveInput;

        if(dashDirection == Vector2.zero)
        {
            dashDirection = Vector2.right; // Defaults not recorded input direction for dashing as right
            stateMachine.Movement.StartDash(
                dashDirection
        );
        }
    }

    public override void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            stateMachine.ChangeState(
                stateMachine.idle // Idle state acts as in between for all states.
            );
        }
    }

    public override void Exit()
    {
        stateMachine.Movement.StopDash();   
    }

}
