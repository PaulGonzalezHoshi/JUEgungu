using Unity.VisualScripting;
using UnityEngine;

internal interface IEnemyDetectPlayerEvents
{
    public void HandlePlayerDetected();
    public void HandlePlayerStay();
    public void HandlePlayerLost();
    public void HandlePlayerNear();
}