using UnityEngine;

public class HideInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] Animator animator;
    [SerializeField] HiddingPlace hiddingPlace;
    [SerializeField] VisibilityManager visibilityManager;
    [SerializeField] HideInteractable otherDoor;
    public bool isOcupped;
    public void Interact()
    {
        animator.SetTrigger("Start");

        if (!isOcupped)
        {
            isOcupped = true;
            otherDoor.isOcupped = true;
            visibilityManager.Hide(hiddingPlace, transform.parent.position);
        }
        else
        {
            isOcupped = false;
            otherDoor.isOcupped = false;
            visibilityManager.Unhide();
        }
    }
}
