using UnityEngine;

public interface ICameraRayCast
{
    public bool GetGOHitted(out RaycastHit hit);
}
