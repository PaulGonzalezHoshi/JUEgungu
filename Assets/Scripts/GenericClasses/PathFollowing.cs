using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public abstract class PathFollowing : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator ani;
    [SerializeField] protected AgentAnimation agentAnimation;
    [SerializeField] [Range(1, 10)] protected float velocityRun;
    [SerializeField] protected Transform[] routePoints;
    protected Vector3 point;
    protected int routePointNumber = 0;
    protected IPlayerDetect playerDetect;

    private void Awake()
    {
        agent.updatePosition = false;
        playerDetect = GetComponent<PlayerDetection>();    
    }

    private void Update()
    {
        if (agent.enabled)
        {
            HandleMovement();
        }
    }

    public abstract void HandleMovement();
    public abstract void Movement();
    public abstract void ChangePoint();

    /// <summary>
    /// Reactivates the NavMeshAgent component to enable movement.
    /// </summary>
    public virtual void ReactivateAgent()
    {
        agent.enabled = true;
    }

    public abstract void VerifyDoor(Vector3 forward);

    /// <summary>
    /// Sets the NavMeshAgent's destination to the next route point.
    /// </summary>
    public void SetDestination()
    {
        agent.destination = point;
    }
    public void CheckPointProximity()
    {
        if (agent.remainingDistance < 0.5f)
        {
            ChangePoint();
        }
    }

    protected bool TryGetComponent<T>(RaycastHit hitInfo, out T component) where T : class
    {
        component = hitInfo.transform.GetComponent<T>();
        return component != null;
    }
}
