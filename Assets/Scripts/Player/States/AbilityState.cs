using UnityEngine;

public class AbilityState : PlayerState
{
    public AbilityState(PlayerStateMachine machine)
        : base(machine)
    {
        
    }

    public override void Update()
    {
        stateMachine.Abilities.Tick();

        if (stateMachine.Abilities.AbilityFinished())
        {
            stateMachine.Abilities.Finish();

            stateMachine.ChangeState(
                stateMachine.Idle);
            
        }
    }

    


}