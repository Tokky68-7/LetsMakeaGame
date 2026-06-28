using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 Velocity { get; set; }

    private Vector2 walkingVelocity;
    public Vector2 WalkingVelocity => walkingVelocity; //accessor for other scripts to read the walking velocity without being able to modify it directly
    private Vector2 dashVelocity;
    private Vector2 knockbackVelocity; 
    // takes different velocities from different functions (game actions) can be expanded to include more sources

    public void SetWalkingVelocity(Vector2 velocity)
    {
        walkingVelocity = velocity;
    }

    public void SetDashVelocity(Vector2 velocity)
        {
            dashVelocity = velocity;
        }

    public void SetKnockbackVelocity(Vector2 velocity)
    {
        knockbackVelocity = velocity;
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = 
            walkingVelocity 
            + dashVelocity
            + knockbackVelocity;
    }
}
