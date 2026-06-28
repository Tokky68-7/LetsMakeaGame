using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 Velocity { get; set; }

    [SerializeField] 
    private float maxSpeed = 10f;
    [SerializeField]
    private float acceleration = 40f;
    [SerializeField]
    private float deceleration = 80f;


    private Vector2 moveIntent;

    public void SetMoveIntent(Vector2 direction)
    {
        moveIntent = direction.normalized;
    }


    private Vector2 walkingVelocity;
    public Vector2 WalkingVelocity => walkingVelocity; //accessor for other scripts to read the walking velocity without being able to modify it directly
    private Vector2 dashVelocity;
    private Vector2 knockbackVelocity; 
    // takes different velocities from different functions (game actions) can be expanded to include more sources

    [SerializeField]
    private float dashSpeed = 20f;

    public void StartDash(Vector2 direction)
    {
        dashVelocity =
            direction.normalized *dashSpeed;
    }

    public void StopDash()
    {
        dashVelocity = Vector2.zero;
    }

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

    private void UpdateWalkingVelocity()
    {
        Vector2 desiredVelocity = moveIntent * maxSpeed;

        float accelRate = 
            moveIntent == Vector2.zero
            ? deceleration
            : acceleration;

        walkingVelocity = Vector2.MoveTowards(
            walkingVelocity,
            desiredVelocity,
            accelRate * Time.fixedDeltaTime
        );
    }

    




    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        UpdateWalkingVelocity();

        ApplyMovement();
    }

    private void ApplyMovement()
    {
        Vector2 finalVelocity = 
            walkingVelocity
            + dashVelocity
            + knockbackVelocity;
        
        rb.linearVelocity = finalVelocity;
    }

}
