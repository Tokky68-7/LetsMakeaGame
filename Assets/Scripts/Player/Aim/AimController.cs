using UnityEditor.Experimental.GraphView;
using UnityEngine;
// only answers where the player is aiming.
public class AimController : MonoBehaviour
{
    private InputHandler input;

    public Vector2 AimDirection {get; private set;}

    [SerializeField]
    private float aimDistance = 5f;

    [SerializeField]
    private float coneAngle = 30f; // half angle

    [SerializeField]
    private int segments = 20;




    void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    void Start()
    {
        Debug.Log("Aim controller inisialised.");
    }

    void Update()
    {
        Vector2 playerPosition = transform.position;

        AimDirection = 
            (input.MouseWorldPosition - playerPosition).normalized;

        Debug.Log("mouse " + input.MouseWorldPosition);
        Debug.Log("aim " + AimDirection);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)AimDirection * 20f
        );
        Vector2 left = 
            Quaternion.AngleAxis(-coneAngle, Vector3.forward)
            * AimDirection;

        Vector2 right = 
        Quaternion.AngleAxis(coneAngle, Vector3.forward)
        * AimDirection;

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)left * aimDistance
        );

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)right * aimDistance    
        );

        Vector3 previousPoint = 
            transform.position + (Vector3)(left * aimDistance);

        for (int i = 1; i <= segments ; i++)
        {
            float angle = 
            Mathf.Lerp(-coneAngle, coneAngle,
            i / (float)segments);

            Vector2 direction = 
                Quaternion.AngleAxis(angle, Vector3.forward)
                * AimDirection;

            Vector3 nextPoint = 
            transform.position +
            (Vector3)(direction * aimDistance);

            Gizmos.DrawLine(previousPoint, nextPoint);

            previousPoint = nextPoint;
        }


    }
}
