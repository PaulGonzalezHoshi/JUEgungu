using UnityEngine;
using UnityEngine.AI;

public class KiyomiEvents : MonoBehaviour, IEnemyDetectPlayerEvents
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator ani;
    [SerializeField] PathFollowing pathFollowing;
    private IKiyomiData kiyomiData;
    private IDataPlayer playerData;

    private void Start()
    {
        kiyomiData = GetComponent<KiyomiPathFollowing>();
        playerData = FindAnyObjectByType<Player>();
    }

    public void HandlePlayerDetected()
    {
        if (!agent.enabled) pathFollowing.ReactivateAgent();
        agent.speed *= kiyomiData.VelocityRun;
        ani.SetBool("Focused", true);
    }

    public void HandlePlayerStay()
    {
        agent.destination = playerData.GetPosition();
    }

    public void HandlePlayerLost()
    {
        ani.SetBool("Focused", false);
        agent.speed /= kiyomiData.VelocityRun;
        pathFollowing.SetDestination();
    }

    public void HandlePlayerNear()
    {
        //Debug.Log("Ataqueeee");
        //ani.SetTrigger("Attack");
    }
}
