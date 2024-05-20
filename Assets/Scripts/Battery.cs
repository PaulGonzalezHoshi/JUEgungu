using UnityEngine;

public class Battery : MonoBehaviour, IActionItem
{
    [SerializeField] private Flashlight flashlight;
    public bool Action()
    {
        if(flashlight.Battery != 100)
        {
            flashlight.RechargeBattery();
            return true;
        }
        else
        {
            return false;
        }
    }
}
