using UnityEngine;

public class KiyomiPathFollowing : PathFollowing, IKiyomiData
{
    public float VelocityRun => velocityRun;

    public override void HandleMovement()
    {
        if (!playerDetect.PlayerDetected)
        {
            CheckPointProximity();
            if (agentAnimation.VerifyAnimationOnChangePoint(point)) return; // Early exit if animation change is necessary.
            SetDestination();
        }
        Movement();
    }

    public override void Movement()
    {
        Vector3 worldDeltaPosition = (agent.nextPosition - transform.position).normalized;
        transform.position = agent.nextPosition;

        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);

        ani.SetBool("Move", dy > 0.1f);
        ani.SetFloat("BlendX", dx);
        ani.SetFloat("BlendY", dy);

        VerifyDoor(worldDeltaPosition);
    }

    public override void ChangePoint()
    {
        if (routePoints.Length == 0) return;

        point = routePoints[routePointNumber].position;
        routePointNumber = (routePointNumber + 1) % routePoints.Length;
    }

    public override void VerifyDoor(Vector3 forward)
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 0.56f, 0), forward, out RaycastHit hitInfo, 1))
        {
            if (TryGetComponent(hitInfo, out IInteractable doorInteractable) &&
                TryGetComponent(hitInfo, out IDoorProperties doorProperties) &&
                !doorProperties.IsOpened)
            {
                doorInteractable.Interact();
            }
        }
    }
}
