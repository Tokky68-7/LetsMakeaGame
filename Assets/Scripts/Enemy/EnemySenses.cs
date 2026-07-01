using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemySenses : MonoBehaviour
{   
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float detectionRange = 10f;

    [SerializeField]
    PlayerStateMachine playerStateMachine = null;

    public Transform Player => player;
    public bool HasPlayer => player != null;
    public Vector2 DirectionToPlayer { get; private set; }
    public float DistanceToPlayer { get; private set; }
    public bool CanDetectPlayer {get; private set; }

    void Awake()
    {  
        if (playerStateMachine != null)
        {
            playerStateMachine = FindFirstObjectByType<PlayerStateMachine>();
            player = playerStateMachine.transform;
        }
    } 

    void Update()
    {
        if (player == null)
        {
            DirectionToPlayer = Vector2.zero;
            DistanceToPlayer = Mathf.Infinity;
            CanDetectPlayer = false;
            return;
        }
        
        Vector2 toPlayer = player.position - transform.position;

        DirectionToPlayer = toPlayer.normalized;
        DistanceToPlayer = toPlayer.magnitude;
        CanDetectPlayer = DistanceToPlayer <= detectionRange;

    }

}
