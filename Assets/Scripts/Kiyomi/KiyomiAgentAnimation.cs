using UnityEngine;

public class KiyomiAgentAnimation : AgentAnimation
{
    public override bool VerifyAnimationOnChangePoint(Vector3 point)
    {
        Vector3 nextRoutePosition = point - transform.position;
        Vector2 deltaPosition = new Vector2(Vector3.Dot(transform.right, nextRoutePosition), Vector3.Dot(transform.forward, nextRoutePosition)).normalized;

        string animation = GetTurnAnimation(deltaPosition);
        if (!string.IsNullOrEmpty(animation))
        {
            StartTurnAnimation(animation);
            return true;
        }

        return false;
    }
    public override string GetTurnAnimation(Vector2 deltaPosition)
    {
        if (deltaPosition.x > 0.75f && deltaPosition.y < -0.1f)
        {
            return "Right Turn";
        }
        else if (deltaPosition.x < -0.75f && deltaPosition.y < -0.1f)
        {
            return "Left Turn";
        }

        return string.Empty;
    }
}
