
using Unity.VisualScripting;
using UnityEngine;

public class GoonStateMachine : MonoBehaviour
{
    public MovementController Movement {get; private set;}
    public  Health Health {get; private set;}
    public AbilityController Abilities {get; private set;}
    public EnemySenses Senses {get; private set;}

    private Vector2 MoveIntent;
    [SerializeField]
    private float OrbitRadius = 5f;

    void Awake()
    {
        Movement = GetComponent<MovementController>();
        Health = GetComponent<Health>();
        Abilities = GetComponent<AbilityController>();
        Senses = GetComponent<EnemySenses>();


    }

    void Update()
    {
        
        if (Senses.CanDetectPlayer)
        {
            GetMoveIntent();
            Movement.SetMoveIntent(MoveIntent);
        }

        else
        {
            Movement.SetMoveIntent(Vector2.zero);
        }
    }

    void GetMoveIntent()
    {
        float distanceDifference = Senses.DistanceToPlayer - OrbitRadius;

        Vector2 toPlayer = Senses.DirectionToPlayer;
        Vector2 orbitDirection = new Vector2(-toPlayer.x, -toPlayer.y);

        if (Mathf.Abs(distanceDifference) > 0.5f)
        MoveIntent = (orbitDirection + toPlayer * distanceDifference).normalized;
        else 
        MoveIntent = Vector2.zero;
    }
    


}
