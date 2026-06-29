using Unity.VisualScripting;
using UnityEngine;

public class SwordState : AbilityState
{
    public SwordState(PlayerStateMachine machine)
        : base(machine)
    {
        
    }
    public AbilityController abilityController {get; private set;}

    public override void Enter()
    {
        base.Enter();

        stateMachine.Abilities.Activate<SwordAbility>();
    }

    public override void Update()
    {
        base.Update();
    }


    public override void Exit()
    {
        stateMachine.Abilities.Finish<SwordAbility>();
    }
    



}
