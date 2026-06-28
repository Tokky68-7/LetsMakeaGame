using UnityEngine;

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

    public IdleState idle { get; private set;}
    public DashingState dashing {get; private set;}



    void Awake()
    {
        idle = new IdleState(this);
        dashing = new DashingState(this);

        Input = GetComponent<InputHandler>();
        Movement = GetComponent<MovementController>();
        Health = GetComponent<Health>();



    }


    void Start()
    {
        ChangeState(idle);
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
