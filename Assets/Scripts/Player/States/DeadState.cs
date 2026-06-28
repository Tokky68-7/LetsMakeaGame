using Unity.VisualScripting;
using UnityEngine;

public class DeadState : AbilityState
{
    public DeadState(PlayerStateMachine machine)
        : base (machine)
    {
        
    }

    public AbilityController abilityController {get; private set;}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("You are Dead");
    }

}
