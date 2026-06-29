using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(InputHandler))]
public class PlayerMovement : MonoBehaviour
{

    private InputHandler input;

    private MovementController movement;

    void Awake()
    {
        input = GetComponent<InputHandler>();
        movement = GetComponent<MovementController>();
    }

    void Update()
    {
        movement.SetMoveIntent(input.MoveInput);
    }
        
        
}
