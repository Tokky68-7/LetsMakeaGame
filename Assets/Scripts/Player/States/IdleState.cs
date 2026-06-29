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
        Debug.Log("Entered Idle");
    }

    public override void Update()
    {
        stateMachine.Movement.SetMoveIntent(
            stateMachine.Input.MoveInput);

        if (stateMachine.Input.DashPressed)
        {
            if (stateMachine.Abilities.Activate<DashAbility>())
            {
                stateMachine.ChangeState(
                    stateMachine.Ability);  
                
            }
        }
    }
}
