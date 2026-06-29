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
    }
}
