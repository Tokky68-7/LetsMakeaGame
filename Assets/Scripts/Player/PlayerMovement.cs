using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float v_max = 10f;
    public float a_const = 40f;
    public float d_const = 80f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Debug.Log("PlayerMovement started");
        
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 c_vel = rb.linearVelocity;
        Vector2 accel = new Vector2(h, v) * speed;

        Vector2 direction = new Vector2(h, v).normalized;
        Vector2 desiredVelocity = direction * v_max;


        float accelRate =
            direction == Vector2.zero ?
            d_const : a_const;

        

        if(rb.linearVelocity.magnitude < 0.1f * v_max)
        {
            accelRate += 0.5f * a_const;
        }

        rb.linearVelocity = Vector2.MoveTowards(
            rb.linearVelocity,
            desiredVelocity,
            accelRate * Time.fixedDeltaTime);
        
    
    }
}