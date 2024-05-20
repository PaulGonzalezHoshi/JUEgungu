using UnityEngine;
using UnityEngine.AI;

public abstract class AgentAnimation : MonoBehaviour
{
    [SerializeField] protected Animator ani;
    [SerializeField] protected NavMeshAgent agent;
    
    public abstract bool VerifyAnimationOnChangePoint(Vector3 point);

    public void StartTurnAnimation(string animation)
    {
        agent.enabled = false;
        ani.SetTrigger(animation);
    }

    public abstract string GetTurnAnimation(Vector2 deltaPosition);
}