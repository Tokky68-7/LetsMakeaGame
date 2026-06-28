using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(InputHandler))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float v_max = 10f;
    [SerializeField]
    private float a_const = 40f;
    [SerializeField]
    private float d_const = 80f;

    private InputHandler input;

    private MovementController movement;


    void Awake()
    {
        input = GetComponent<InputHandler>();
        movement = GetComponent<MovementController>();

    }

    void Start()
    {
        Debug.Log("PlayerMovement started");
        
    }
    void FixedUpdate() // for physics calculations, physics incase we wana do explosions or knockback etc.
    {

        Move();
    }

    private void Move()
    {
        Vector2 direction = input.MoveInput.normalized;

        Vector2 desiredVelocity = direction * v_max;


        float accelRate =
            direction == Vector2.zero
            ? d_const 
            : a_const;

        movement.SetWalkingVelocity(
            Vector2.MoveTowards(
                movement.WalkingVelocity,
                desiredVelocity,
                accelRate * Time.fixedDeltaTime
            )
        );

    

        
        
    
    }
}