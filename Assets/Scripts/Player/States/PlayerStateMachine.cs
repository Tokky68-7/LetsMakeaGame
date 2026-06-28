using UnityEngine;
using UnityEngine.UIElements;
// The state machine should only handle states, no code describing actual mechanics
// States should then have a clause for start end exit defined by some ability or other class that handles specific logic
// 
public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState currentState;

    public void ChangeState(PlayerState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
       
    }

    public InputHandler Input { get; private set; }
    public MovementController Movement{ get; private set; }
    public Health Health { get; private set; }
    public AbilityController Abilities {get; private set;}


    public IdleState Idle { get; private set; }

    public AbilityState Ability { get; private set;}

    public DeadState Dead { get; private set;}

void Awake()
    {
        Input = GetComponent<InputHandler>();
        Movement = GetComponent<MovementController>();
        Health = GetComponent<Health>();
        Abilities = GetComponent<AbilityController>();

        Idle = new IdleState(this);
        Ability = new AbilityState(this);
        Dead = new DeadState(this);
        
    
    }


    void Start()    
    {
        ChangeState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }

    void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }
}
