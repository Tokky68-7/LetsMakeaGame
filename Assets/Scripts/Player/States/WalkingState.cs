using UnityEngine;

public class WalkingState : PlayerState
{
    public WalkingState(PlayerStateMachine machine)
        : base(machine)
    {

    }

    public override void Enter()
    {
        Debug.Log("Entered Walking");
    }

    public override void Update()
    {
         // 
    }

}
