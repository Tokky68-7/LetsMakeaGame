using UnityEngine;

public class AbilityState : PlayerState
{
    public AbilityState(PlayerStateMachine machine)
        : base(machine)
    {
        
    }

    public override void Update()
    {
        if (stateMachine.Abilities.AbilityFinished())
        {
            stateMachine.ChangeState(
                stateMachine.Idle);
            
        }
    }

    


}
