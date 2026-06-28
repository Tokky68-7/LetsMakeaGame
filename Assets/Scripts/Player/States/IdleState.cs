using Unity.VisualScripting;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerStateMachine machine)
        : base(machine)
    {

    }

    public override void Enter()
    {
        Debug.Log("Etnered Idle");
    }

    public override void Update()
    {
        stateMachine.Movement.SetMoveIntent(
            stateMachine.Input.MoveInput
        );

        if(stateMachine.Input.DashPressed)
        {
            stateMachine.ChangeState(stateMachine.dashing);
        }
    }

}
