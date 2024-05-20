using UnityEngine;

public class AnimationDoorInteractable : MonoBehaviour, IInteractable, IDoorProperties, IOtherDoorProperties
{
    [SerializeField] private bool isLocked;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject otherDoor;
    [SerializeField] private IDoorProperties otherDoorProperties;

    public bool IsLocked { get => isLocked; set => isLocked = value; }
    public bool IsOpened { get; set; }
    public bool HasOtherDoor { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = animator == null ? GetComponent<Animator>() : animator;
        IsLocked = isLocked;
        if(otherDoor != null)
        {
            otherDoorProperties = otherDoor.GetComponent<IDoorProperties>();
            HasOtherDoor = true;
        }
    }

    public void Interact()
    {
        if (!isLocked)
        {
            bool newState = !animator.GetBool("Start");
            IsOpened = newState;
            if (otherDoor != null) otherDoorProperties.IsOpened = newState;
            animator.SetBool("Start", newState);
        }
    }
    public void SetStartFalse()
    {
        animator.SetBool("Start", false);
    }

    public void LockedEvent()
    {

    }

    public void UnlockDoor()
    {
        isLocked = false;
        if(HasOtherDoor) otherDoorProperties.IsLocked = false;
    }
}
