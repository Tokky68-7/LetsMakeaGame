using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    public bool DashPressed { get; private set; }

    public bool AttackPressed { get; private set;}

    void Update()
    {
        ReadMovementInput();
        
        ReadActionInput();

    }

    private void ReadMovementInput()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void ReadActionInput()
    {
        DashPressed = Input.GetKeyDown(KeyCode.Space);
        
        AttackPressed = Input.GetKeyDown(KeyCode.Mouse0);
    }


}