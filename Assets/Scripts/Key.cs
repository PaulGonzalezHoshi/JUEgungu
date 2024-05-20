using UnityEngine;

public class Key : MonoBehaviour, IActionItem
{
    [SerializeField] private string doorName;
    private ICameraRayCast cameraRayCast;

    // Start is called before the first frame update
    void Start()
    {
        cameraRayCast = FindAnyObjectByType<CameraRayCast>();
    }

    public bool Action()
    {
        if(cameraRayCast.GetGOHitted(out RaycastHit hitInfo))
        {
            if(doorName == hitInfo.transform.name)
            {
                hitInfo.transform.GetComponent<IDoorProperties>().UnlockDoor();

                return true;
            }
        }

        return false;
    }
}
