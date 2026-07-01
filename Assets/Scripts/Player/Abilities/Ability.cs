
using UnityEngine;

public abstract class Ability : MonoBehaviour
{

    protected PlayerStateMachine stateMachine;

    protected MovementController movement;

    protected virtual void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        movement = GetComponent<MovementController>();
    }

    public abstract bool CanActivate();

    public abstract void Begin();

    public abstract void Tick();

    public abstract void Cooldown();

    public abstract void End();

    public abstract bool Finished();

}
