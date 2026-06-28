using Unity.VisualScripting;
using UnityEngine;

public class DashingState : AbilityState
{
    public DashingState(PlayerStateMachine machine)
        : base(machine) // timer duration
    {

    }


    public AbilityController abilityController {get; private set;}

  

    public override void Enter()
    {
        base.Enter();

        stateMachine.Abilities
            .GetAbility<DashAbility>()
            .Begin();
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Abilities.Tick();
    }


    public override void Exit()
    {
        stateMachine.Abilities.Finish();
    }

}
